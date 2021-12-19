# Geek I Am Articles database




### Generating database migrations

In the root of the project directory there is a docker compose file which enables setting a simple PostgreSql database on the local machine.
This database is just used to enable creating migrations and testing them,



#### Install EF Core tool

```sh
dotnet tool install --global dotnet-ef
```

#### Update Tool

```sh
dotnet tool update --global dotnet-ef
```

### Verify Installation

```sh
dotnet ef
```