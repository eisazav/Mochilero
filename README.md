# HikersApp

this a technical interview for an analyst frontend developer
the frontend was made in Express using html, javascript(Ajax), and CSS [VANILA PROJECT] and the Web Api was built in Dotnet 9 using a hexagonal architecture

## Note:
 By default, the backend is running on port 5299 and the frontend is running on port 3000.
 You can change the port of the backend in the frontend in the file [ApiFile](./frontend/engine/apiService.js)

This project uses postgres sql database, you can run postgres on your computer using following docker command: 

```sh
docker run --name my_postgres_container -e POSTGRES_USER=hickers -e POSTGRES_PASSWORD=supersecretpwd -p 5432:5432 -d postgres:latest
```

Also, if you need to change the SQL String Connection you can do it [Here](./src/WebApi/appsettings.json)

# Migrations

## Notes:
 by default the aplication creates a new database called Hikersdb and runs the migrations

Make migration to database

```sh
cd src/WebApi && dotnet ef migrations add --project ../Infrastructure/ adding_seed
```

Update database

```sh
cd src/WebApi && dotnet ef database update -p ../Infrastructure/
```

# Run the Backend

Build the project

```sh
cd src/WebApi && dotnet build
```

Run the project

```sh
cd src/WebApi && dotnet run
```

# Run the frontend

install dependencies of express

```sh
cd frontend && npm i
```

Run the project

```sh
cd frontend && npm start
```
# Access to the aplication
You can access the aplication in the next url: [Frontend](http://localhost:3000)

# API Documentation
You can access the API Documentation in the next url: [Swagger](http://localhost:5299/swagger)
