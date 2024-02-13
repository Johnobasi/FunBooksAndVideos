# FunBooksAndVideos

## Project setup
```
dotnet restore
```

#How to run the project
```

#Repalce the connection string in appsettings.json
#Add below code in Program.cs
```
```
=================================================================================
#if(args.Length == 1 && args[0]?.ToLower()=="seeddata")
SeedData(app);
//Seed Data
void SeedData(IHost app)
{
   var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

   using (var scope = scopedFactory!.CreateScope())
  {
       var service = scope.ServiceProvider.GetService<DataSeeder>();
     service?.SeedData();
   }
}
=================================================================================
```

```
#Add migration
dotnet ef migrations add InitialCreate

#Update database
dotnet ef database update

#Run the project
dotnet run
```