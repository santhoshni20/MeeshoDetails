# MeeshoDetails

An ASP.NET Core MVC application designed to manage, track, and analyze Meesho seller details, products, orders, and payments.

## Project Structure

This project follows a clean repository and service pattern architecture:

*   **Controllers/** - Handles HTTP requests and returns MVC views or API responses.
*   **Services/** - Contains business logic and orchestrates data operations.
*   **Interfaces/** - Defines contracts for services and repositories to promote loose coupling.
*   **Repositories/** - Data access layer handling database interactions.
*   **Models/** - Contains data transfer objects (DTOs), database entities, and view models.
*   **Helpers/** - Utility classes, extension methods, and helper functions.
*   **Views/** - Razor views for the user interface.
*   **wwwroot/** - Static assets (CSS, JavaScript, Images).

## Getting Started

### Prerequisites

*   .NET 9.0 SDK (or latest)
*   SQL Server / LocalDB (or preferred database system)
*   Visual Studio 2022 or VS Code

### Database Setup

Run the SQL script located at `CreateTables.sql` in your SQL Server database to create the necessary tables:
*   `Sellers`
*   `Products`
*   `Orders`
*   `Payments`

Update the connection string in `appsettings.json` to point to your database.

### Build and Run

To build the project:
```bash
dotnet build
```

To run the project locally:
```bash
dotnet run --project MeeshoDetails
```
