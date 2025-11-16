#Order Management API - Readme 
Overview

The Order Management API allows managing:
Customers
Products
Orders (with order items)
User accounts & roles (JWT)

Customers

Create, update, delete (soft delete)

Pagination + name/email filtering

Unique email enforcement

Products

Create, update, delete

SKU uniqueness enforced

Stock management (increase/decrease)

Pagination + search

Orders

Create order with items (via TVP)

Validate & deduct stock

Calculate totals

Get full order with items

Change order status

Cancel = restore stock

Date range filtering + status filtering

High-performance stored procedure for paging

 Authentication

JWT Bearer tokens

Login, Register, Assign Role

Role-based authorization (Admin/User)

Architecture  Clean /DDD hyprid 
OrderingSystem/
OrderingSystem.Api/               Controllers, Swagger, JWT setup
OrderingSystem.Application/       Services, DTOs, Interfaces
OrderingSystem.Domain/             Entities, ValueObjects, Exceptions
OrderingSystem.Infrastructure/     EF Core, Repositories, SQL, Dapper
OrderingSystem.Tests/            Unit tests


Tech Stack
                               
Backend        : .NET 9 Web API                                 
Data Access    : EF Core, ADO.NET, SQL Server Stored Procedures 
Authentication : JWT Bearer                                     
Documentation  : Swagger / OpenAPI                              
Testing        : xUnit + FluentAssertions                       


Setup instruction : 

Clone the project or download it 

Update the appsettings.json 



Business Rules

Cannot create order if stock is insufficient.

TotalAmount = SUM(LineTotal)

Canceling an order restores stock.

SKU and Email must be unique.

Cannot delete product used in an order.

Cannot delete non-pending orders.




