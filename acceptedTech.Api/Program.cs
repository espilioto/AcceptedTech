using acceptedTech.Application;
using acceptedTech.Infrastructure;
using acceptedTech.Infrastructure.Common.Persistence;
using acceptedTech.Infrastructure.Converters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services
       .AddPresentation()
       .AddApplication()
       .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await dbContext.Database.MigrateAsync();
}

//let's not only show this if IsDevelopment() for the assignment
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
