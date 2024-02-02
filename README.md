# acceptedTech

```
version: '3.7'

services:
  accepted-api:
    image: ghcr.io/espilioto/acceptedtech:master
    container_name: accepted-api
    restart: unless-stopped
    environment:
      - ASPNETCORE_ENVIRONMENT=Production
      - ConnectionStrings__db=Server=accepted-db,14333;User Id=sa;Password=SA_password1;Database=MatchOddsDb;Encrypt=False;
    depends_on:
      - accepted-db
    ports:
      - "8080:8080"

  accepted-db:
    image: mcr.microsoft.com/mssql/server
    container_name: accepted-db
    restart: unless-stopped
    environment:
      SA_PASSWORD: "SA_password1"
      ACCEPT_EULA: "Y"
      MSSQL_PID: "Express"
      MSSQL_TCP_PORT: 14333
    ports:
      - "14333:14333"
```
