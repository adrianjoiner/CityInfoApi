# Working with migration strategies
- Added the Microsoft.EntityFrameworkCore.Tools nuGet package
- Used them to snapshot the db created by our dummycontroller for use as initial db. This creates the Migrations folder int the sln
```
// In package manager console
> Add-Migration CityInfoDBInitialMigration
```

- Manually deleted the db from SQl server explorer else the 'migrate' will try to update the existing rather than create new

