
# Instinct Booking API

The **Instinct Booking API** is a backend microservice responsible for managing appointment reservations for personalized
architectural home design consultations. It handles the complete booking lifecycle:

* **Creation** of new appointments
* **Modification** of existing bookings
* **Retrieval** of scheduled appointments
* **Cancellation** of bookings

This system ensures a reliable and efficient scheduling process between clients and architects within the **Instinct** platform.

---

## 🔨 Tech Stack & Architecture

* **.NET 8** – Modern and high-performance framework for scalable backend development
* **ASP.NET Core Web API** – RESTful API framework used to expose endpoints
* **Entity Framework Core** – ORM for database communication
* **SQL Server** – Relational database for persistent appointment storage
* **Azure Cloud** – Deployment platform for hosting, scaling, and monitoring the service
* **Swagger / OpenAPI** – Interactive API documentation and testing
* **JWT (JSON Web Tokens)** – Secure authentication and authorization mechanism
* **Encryption** – Protection of sensitive user and booking data
* **FluentValidation** – Layered model validation strategy
* **CQRS (Command Query Responsibility Segregation)** – Separation of read and write operations for better scalability and maintainability
* **Monitoring** – Centralized logging and performance tracking
* **Clean Architecture** – Separation of concerns and maintainable project structure

---
