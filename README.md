# Case

## Backend (Web API) & Tests

To run tests (in Tests folder): `dotnet tests`

## Database - MSSQL

From the docker-compose file

To run db (in root folder): `docker-compose up -d mssql`

To run migrations (in Backend folder): `dotnet ef database update`

## Frontend - Vite/Vue.js

Tests: `npm run test`

Install dependencies: `npm i`

Dev environment: `npm run dev`
