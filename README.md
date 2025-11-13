# Manero4

![.NET CI](https://github.com/TomasLam/Manero4/actions/workflows/dotnet-ci.yml/badge.svg)

Ett fullstack e-handelsprojekt byggt med **ASP.NET Core 9** (backend) och React (frontend).

## 🚀 Funktioner (hittills)

- Produkt-API i ASP.NET Core
- SQLite-databas via Entity Framework Core
- Enhetstester (xUnit)
- Integrationstester
- CI/CD med GitHub Actions (bygger + testar automatiskt vid push)

## 🧪 Köra tester lokalt

Kör detta i projektets rotmapp:

```bash
dotnet test backend/Manero.sln --configuration Release
