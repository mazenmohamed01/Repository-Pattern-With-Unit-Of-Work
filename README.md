# Repository Pattern With Unit Of Work 💼

![License](https://img.shields.io/badge/license-MIT-blue.svg)  
![Language](https://img.shields.io/badge/language-C%23-blue.svg) 
![.NET](https://img.shields.io/badge/.NET-purple.svg) 

> A clean and scalable implementation of the **Repository Pattern** and **Unit of Work Pattern** in .NET for better separation of concerns and testability.

---

## 🎯 Overview

This project demonstrates how to implement two essential architectural patterns:
- **Repository Pattern**
- **Unit of Work Pattern**

These patterns help decouple data access logic from business logic, improve code maintainability, and make it easier to test your application.

---

## 🧱 Project Structure
/Repositories
- IRepository.cs
- Repository.cs
/UnitOfWork
- IUnitOfWork.cs
- UnitOfWork.cs
/Data
- AppDbContext.cs
/Models
- Customer.cs
/Program.cs


---

## 🔧 Design Patterns Used

### 1. Repository Pattern

Encapsulates all the logic required to interact with the database into a separate layer.

**Benefits:**
- Centralized data access logic
- Easy to mock for unit testing
- Decouples business logic from data access

### 2. Unit of Work Pattern

Manages transactions across multiple repositories and ensures that all operations either complete successfully or roll back as a single unit.

**Benefits:**
- Ensures data consistency
- Reduces database round-trips by batching changes
- Simplifies transaction management

---

## 💻 Code Examples

### `IRepository.cs`

```csharp
public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T GetById(object id);
    void Insert(T obj);
    void Update(T obj);
    void Delete(object id);
}
