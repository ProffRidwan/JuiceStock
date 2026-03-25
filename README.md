# 🧃 JuiceStock Backend

JuiceStock is a backend inventory and ledger management system built with **ASP.NET Core** following **Clean Architecture principles**.

It is designed to manage the flow of goods between suppliers and customers while accurately tracking financial transactions using a ledger-based system.

---

## 🚀 Features

* ✅ Customer Management
* ✅ Supplier Management
* ✅ Ledger-based Accounting (Credit & Debit)
* ✅ Transaction History (Ledger Entries)
* ✅ Pagination with Metadata
* ✅ Clean Architecture (Domain, Application, Infrastructure, API)
* ✅ DTO-based API Design
* ✅ Entity Framework Core with Migrations

---

## 🧠 Architecture Overview

The project follows **Clean Architecture**, ensuring separation of concerns and maintainability:

```
JuiceStock
├── JuiceStock.Domain          # Core business logic (Entities, Enums)
├── JuiceStock.Application     # Use-cases (Services, Interfaces)
├── JuiceStock.Infrastructure  # Data access (EF Core, Repositories)
├── JuiceStock.Api             # Controllers, DTOs, API layer
```

---

## 🏗️ Tech Stack

* **.NET (ASP.NET Core Web API)**
* **Entity Framework Core**
* **SQL Server**
* **C#**

---

## 📦 Key Concepts Implemented

* Separation between **Domain Entities** and **DTOs**
* Repository Pattern for data access
* Service Layer for business logic
* Ledger system for tracking financial transactions
* Pagination for scalable data retrieval

---

## 📌 Sample Endpoints

### Customers

```
POST   /api/customers
GET    /api/customers/{id}
```

### Suppliers

```
POST   /api/suppliers
GET    /api/suppliers/{id}
```

### Ledger

```
POST   /api/customers/{id}/ledger/credit
POST   /api/customers/{id}/ledger/debit
GET    /api/customers/{id}/ledger?page=1&pageSize=10
```

---

## ▶️ Getting Started

### Prerequisites

* .NET SDK
* SQL Server

---

### Run the Project

```bash
dotnet build
dotnet run --project JuiceStock.Api
```

---

### Apply Migrations

```bash
dotnet ef database update --project JuiceStock.Infrastructure --startup-project JuiceStock.Api
```

---

## 📈 Future Improvements

* Authentication & Authorization
* Advanced Filtering (date range, transaction type)
* CQRS Pattern Implementation
* Unit & Integration Test Expansion
* Frontend (Angular) Integration

---

## 👨‍💻 Author

Built as part of a hands-on journey to deepen backend engineering skills and design scalable systems.

---

## ⭐ Contributing

Feel free to fork the project, suggest improvements, or open issues.

---
