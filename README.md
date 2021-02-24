# Customer Contact Service

## Prerequisites

1. Docker Desktop (WSL 2 backend engine enabled)
2. Visual Studio Code (For devcontainer development)

## Tech used
The micro-service is implemented as a containerized ASP.NET Core Web App with MSSQL as the DB backend, Dapper as ORM, DbUp for DB migration and GraphQL for the API server.

## Spec divergence/simplification
The HR API and notification channel is simplified to its max. There is no real call to an external API and the notifications regarding changed records would normally be posted on some kind of message broker.

Also, in a real scenario the GraphQL API would probably be separated from the customer contact service since these kind of API setups usually calls more than one micro-service to serve queries. That is, some kind of gateway.

The HR API will see all 10 or 12 digit numbers as valid.

## Building & Running

There is a docker-compose with the customer contact service and the database used by the service.

To use:
```
> cd ./docker
```

### Building the Docker image
```
> docker-compose -f docker-compose.yml -f docker-compose.build.override.yml build
```

### Running the system
```
> docker-compose up -d 
```

The GraphQL playground including API documentation is accessed through http://localhost:8042/ui/playground. GraphQL clients would use http://localhost:8042/query as their endpoint.

## Tests
None

