# Instinct Booking API

The **Instinct Booking API** is a backend application built using **Clean Architecture** and the **CQRS (Command Query Responsibility Segregation)** pattern. It is designed to manage appointment bookings for personalized architectural home design consultations.

This API handles the full booking lifecycle:

- **Creation** of new appointments  
- **Modification** of existing bookings  
- **Retrieval** of scheduled appointments  
- **Cancellation** of bookings  

The system ensures a reliable and efficient scheduling process between clients and architects within the **Instinct** platform.

---

## 🧱 Architecture & Design

The application follows **Clean Architecture**, providing a clear separation of concerns through distinct layers (Domain, Application, Infrastructure, and Presentation). It also implements the **CQRS** pattern, separating write (commands) and read (queries) operations to improve scalability, maintainability, and clarity.

---

## 🔨 Tech Stack

- **.NET 8.0** – Modern and high-performance framework for backend development  
- **ASP.NET Core Web API 8.0** – RESTful API framework for exposing endpoints  
- **Entity Framework Core 7.0.9** – ORM for database access  
- **SQL Server** – Relational database for persistent storage  
- **Azure Cloud** – Hosting platform for deployment, scaling, and monitoring  
- **JWT (JSON Web Tokens)** – Secure authentication and authorization  
- **Swagger / OpenAPI** – Interactive API documentation and testing  
- **Encryption** – Protection of sensitive user and booking data  
- **FluentValidation** – Structured model validation  
- **CQRS** – Separation of read and write logic for better system design  
- **Clean Architecture** – Maintainable and scalable project structure