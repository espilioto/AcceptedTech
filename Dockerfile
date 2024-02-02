FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY *.sln .
COPY . .
RUN dotnet restore
WORKDIR "/src/acceptedTech.Api"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "acceptedTech.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "acceptedTech.Api.dll"]