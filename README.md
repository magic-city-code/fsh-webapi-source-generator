# fsh-webapi-source-generator
Source Generator for Full Stack Hero Web API v0.0.5-rc.

This was put together fast, but it has proved to work. This project is nowhere near complete or fully functional, but it works. It's good enough for me to start further exploring Full Stack Hero web API boilerplate.

Thanks to [Full Stack Hero](https://github.com/fullstackhero/) for the Web API boilerplate.

# Required for Each Entity
* Enter new folder created for each entity
  * Copy the contents to the `src` directory of the `Full Stack Hero` solution.
* Modify `PermissionConstants.cs`
* Modify `ApplicationDbContext.cs`
* Create seed JSON file.

# To Do
* Match case in text replace.

# Migrations
https://fullstackhero.net/dotnet-webapi-boilerplate/general/cli-commands/#migrations

* Open Package manager console
* Set `defualt project` to `Infrastructure`
* Run the add migration command.
* Run the update command.

## Add Migration
`dotnet ef migrations add AddMeal --project .././Migrators/Migrators.MSSQL/ --context ApplicationDbContext -o Migrations/Application`

## Update Database
`dotnet ef database update --project .././Migrators/Migrators.MSSQL/ --context ApplicationDbContext`