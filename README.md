## Migration

To create migration, `cd` into the `src/CleanArchitecture.Infrastructure` folder and run - 

```bash
dotnet ef migrations add Initial --startup-project ../CleanArchitecture.API/CleanArchitecture.API.csproj
```