# Fruit API

## Overview
This is a simple API for managing fruit data. It allows users to perform CRUD operations on fruit records.

## Prerequisites
- Docker
- .NET SDK

## Setting Up the Oracle Database

To run the Oracle database using Docker, execute the following command:

```bash
docker run -d -p 1521:1521 -e ORACLE_PASSWORD=password123 gvenzl/oracle-free
```

This command will start an Oracle database container with the specified password.

## Running the Application

Once the database is up and running, you can build and run the application using the following commands:

```bash
dotnet build
dotnet run
```

## API Endpoints
- **GET /fruits**: Retrieve a list of fruits.
- **POST /fruits**: Add a new fruit.
- **PUT /fruits/{id}**: Update an existing fruit.
- **DELETE /fruits/{id}**: Delete a fruit.

## License
This project is licensed under the MIT License.