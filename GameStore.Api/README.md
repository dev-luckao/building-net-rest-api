# Game Store API

## Starting SQL Server
```powershell
$sa_password = "[SA PASSWORD HERE ex. Pass@word123]"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -p 1411:1433 -v sqlvolumn:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest
```

## Using Secret Manager
```powershell
dotnet user-secrets init # first time for initial UserSecretsId in .csproj

$sa_password = "[SA PASSWORD HERE ex. Pass@word123]"
dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Server=localhost; Database=GameStore; User Id=sa; Password=$sa_password; TrustServerCertificate=True"
```

## Generating Database Migrations
```powershell
dotnet tool install --global dotnet-ef --version 8.0.12
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.12

dotnet ef migrations add InitialCreate --output-dir Data\Migrations
```