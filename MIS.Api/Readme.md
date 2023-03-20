### Migrations. Next commands run from root project folder

### Create migration
dotnet ef migrations add <MigrationName> -s MIS.API -p MIS.Data -c MisContext -v

### Update database from selected migration
dotnet ef database update <MigrationName> -s MIS.API -p MIS.Data -c MisContext -v

### Remove last migration
dotnet ef migrations remove -s MIS.API -p MIS.Data -c MisContext -v

