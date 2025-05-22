# Product Management Application

## Overview
The **Product Management Application** is a web application developed using **ASP.NET Core MVC** to manage products for a store named **ProductStore**. The application supports **CRUD** operations (Create, Read, Update, Delete) for products and includes user authentication via session management. It uses **Entity Framework Core** to interact with a SQL Server database and implements a layered architecture with **Repository Pattern** for better maintainability and scalability.

This project was developed as part of **Lab 01** for learning ASP.NET Core MVC, Entity Framework Core, and modern software design patterns.

---

## Features
- **CRUD Operations**: Add, view, modify, and delete products.
- **User Authentication**: Login and logout functionality with session management.
- **Database Integration**: Uses SQL Server database (`MyStoreDB`) with Entity Framework Core.
- **Layered Architecture**:
  - **BusinessObjects**: Contains data models (`Product`, `Category`, `AccountMember`).
  - **DataAccessObjects**: Handles database operations using EF Core.
  - **Repositories**: Provides an abstraction layer for data access.
  - **Services**: Implements business logic.
  - **ProductManagementMVC**: ASP.NET Core MVC web application with controllers and views.
- **Dependency Injection**: Used for loose coupling between layers.
- **Session Management**: Stores user information during authenticated sessions.

---

## Technologies Used
- **Framework**: ASP.NET Core 8.0
- **Database**: SQL Server (MyStoreDB)
- **ORM**: Entity Framework Core 8.0.2
- **Design Pattern**: Repository Pattern
- **Web Server**: Kestrel
- **Frontend**: Razor Views with HTML, CSS, Bootstrap
- **IDE**: Visual Studio 2022
- **NuGet Packages**:
  - Microsoft.EntityFrameworkCore.SqlServer (8.0.2)
  - Microsoft.EntityFrameworkCore.Tools (8.0.2)
  - Microsoft.Extensions.Configuration.Json (8.0.0)

---

## Project Structure
The solution (`ProductManagementASPNETCoreMVC.sln`) consists of five projects:
1. **BusinessObjects**: Defines data models (`Product`, `Category`, `AccountMember`).
2. **DataAccessObjects**: Contains EF Core DbContext (`MyStoreContext`) and DAO classes for database operations.
3. **Repositories**: Implements repository interfaces and classes for data abstraction.
4. **Services**: Handles business logic through service interfaces and classes.
5. **ProductManagementMVC**: ASP.NET Core MVC application with controllers, views, and session management.

---

## Database Schema
The application uses a SQL Server database named `MyStoreDB` with three tables:
- **Categories**:
  - `CategoryId` (PK, int)
  - `CategoryName` (nvarchar(100))
- **Products**:
  - `ProductId` (PK, int)
  - `ProductName` (nvarchar(100))
  - `CategoryId` (FK, int, references Categories)
  - `UnitsInStock` (int)
  - `UnitPrice` (decimal(18,2))
- **AccountMember**:
  - `MemberId` (PK, nvarchar(50))
  - `EmailAddress` (nvarchar(100))
  - `FullName` (nvarchar(100))
  - `MemberPassword` (nvarchar(100))

---

## Prerequisites
To run this project, ensure you have the following installed:
- **Visual Studio 2022** (or later) with .NET 8 workload.
- **.NET 8 SDK** (version 8.0.202 or later).
- **SQL Server** (LocalDB or full SQL Server instance).
- **Entity Framework Core CLI** (`dotnet-ef` version 8.0.2).
- **Git** (optional, for cloning the repository).

---

## Setup Instructions
Follow these steps to set up and run the project locally:

### 1. Clone the Repository
```bash
git clone <repository-url>
cd ProductManagementASPNETCoreMVC
```

### 2. Set Up the Database
1. Open **SQL Server Management Studio (SSMS)** or any SQL client.
2. Create a database named `MyStore`:
   ```sql
   CREATE DATABASE MyStore;
   ```
3. Run the following SQL script to create tables:
   ```sql
   USE MyStore;

   CREATE TABLE Categories (
       CategoryId INT PRIMARY KEY IDENTITY(1,1),
       CategoryName NVARCHAR(100) NOT NULL
   );

   CREATE TABLE Products (
       ProductId INT PRIMARY KEY IDENTITY(1,1),
       ProductName NVARCHAR(100) NOT NULL,
       CategoryId INT FOREIGN KEY REFERENCES Categories(CategoryId),
       UnitsInStock INT,
       UnitPrice DECIMAL(18,2)
   );

   CREATE TABLE AccountMember (
       MemberId NVARCHAR(50) PRIMARY KEY,
       EmailAddress NVARCHAR(100) NOT NULL,
       FullName NVARCHAR(100),
       MemberPassword NVARCHAR(100) NOT NULL
   );
   ```
4. Insert sample data (optional):
   ```sql
   INSERT INTO Categories (CategoryName) VALUES ('Electronics'), ('Clothing');
   INSERT INTO Products (ProductName, CategoryId, UnitsInStock, UnitPrice)
   VALUES ('Laptop', 1, 50, 999.99), ('T-Shirt', 2, 100, 19.99);
   INSERT INTO AccountMember (MemberId, EmailAddress, FullName, MemberPassword)
   VALUES ('user1', 'user@example.com', 'John Doe', 'password123');
   ```

### 3. Configure Connection String
1. Open `appsettings.json` in the `ProductManagementMVC` project.
2. Update the connection string to match your SQL Server setup:
   ```json
   {
     "ConnectionStrings": {
       "MyStockDB": "Server=localhost;uid=sa;pwd=1234567890;database=MyStore;TrustServerCertificate=True"
     }
   }
   ```
   - Replace `Server`, `uid`, `pwd` with your SQL Server credentials.

### 4. Restore NuGet Packages
1. Open Visual Studio 2022 and load the solution (`ProductManagementASPNETCoreMVC.sln`).
2. Right-click the solution in **Solution Explorer** → Select **Restore NuGet Packages**.

### 5. Install EF Core CLI (if not installed)
```bash
dotnet tool install --global dotnet-ef --version 8.0.2
```

### 6. Build and Run the Project
1. Set `ProductManagementMVC` as the **Startup Project** (right-click → Set as Startup Project).
2. Press **F5** to build and run.
3. The application will open in your default browser at `https://localhost:<port>` (e.g., `https://localhost:5001`).

### 7. Test the Application
- **Login**: Navigate to `/Account/Login` and use credentials (e.g., `user@example.com`, `password123`).
- **CRUD Operations**:
  - View product list: `/Products`.
  - Create a product: `/Products/Create`.
  - Edit a product: `/Products/Edit/<id>`.
  - Delete a product: `/Products/Delete/<id>`.
- **Logout**: Navigate to `/Account/Logout`.

---

## Usage
- **Login**: Authenticate using an email and password stored in the `AccountMember` table.
- **Product Management**:
  - View all products in a table format.
  - Add new products with details (name, category, stock, price).
  - Edit or delete existing products.
- **Session Management**: User information is stored in session and cleared on logout.

---

## Troubleshooting
- **Database Connection Issues**:
  - Verify the connection string in `appsettings.json`.
  - Ensure SQL Server is running and accessible.
- **EF Core Errors**:
  - Check if `dotnet-ef` is installed (`dotnet ef --version`).
  - Ensure NuGet packages are restored.
- **404 Errors**:
  - Verify routing in `Program.cs` (`MapControllerRoute`).
  - Check if controllers and views are correctly named.
- **Session Issues**:
  - Ensure `AddSession` and `UseSession` are configured in `Program.cs`.

---

## Project Architecture
The application follows a **layered architecture**:
1. **BusinessObjects**: Defines entities (`Product`, `Category`, `AccountMember`) mapped