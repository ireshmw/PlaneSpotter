# PlaneSpotter
Web application to assist plane spotters

## Frontend -  Blazor Webassembly with Ant Design Blazor Components
## Backend  - .NET Core Web API (ORM - Entity Framework)

# Project setup instuctions

01) Goto 'PlaneSpotter.Server' folder and open appsettings.json then change relevant DB-Connection

```bash
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433; Database=plane-sight-db; User=sa; Password =0717645590Sa;"
  },
  ```

02) Open the Package Manager Console and run the following commands (This will create the DB using Entity Framework)

```bash
cd .\PlaneSpotter\Server
dotnet ef database update
```
