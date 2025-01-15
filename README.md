# Bank Accounts Api 

## Tools and Technologies Needed

- [Dotnet 9.0 SDK](https://dotnet.microsoft.com/download)
- [node.js](https://nodejs.org/en/)
- [pnpm](https://pnpm.io/)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

### Commands

- **dev**: Builds and starts the Docker containers.
  ```sh
  pnpm dev
  ```

- **down**: Stops and removes the Docker containers.
  ```sh
  pnpm down
  ```

- **restore**: Restores the .NET project dependencies.
  ```sh
  pnpm restore
  ```

- **build**: Builds the .NET project in Release configuration without restoring dependencies.
  ```sh
  pnpm build
  ```

- **publish**: Publishes the .NET project in Release configuration without restoring or building.
  ```sh
  pnpm publish
  ```

- **migrate:add**: Adds a new migration to the `Infrastructure` project.
  ```sh
  pnpm migrate:add -- <MigrationName>
  ```

- **migrate:sql**: Generates a SQL script for the current migrations.
  ```sh
  pnpm migrate:sql
  ```

- **prepare**: Sets up Husky for managing Git hooks.
  ```sh
  pnpm prepare
  ```

## Ports - localhost

- **API**: (Docker: 5000) | (Launch Settings: 5001)
  - **Swagger**: /swagger/index.html
- **Postgres**: 5432
- **Redis**: 6379
