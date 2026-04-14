Product Catalog API

Overview

This is a sample RESTful API built using ASP.NET Core and Entity Framework Core.
It allows users to manage products including creating, retrieving, updating, and deleting data.

Features
- Full CRUD operations
- SQL Server integration
- DTO pattern for data validation
- Service layer for business logic
- Async/Await for performance

Technologies Used
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger (OpenAPI)

API Endpoints

Method	        Endpoint		              Description

GET	            /api/products		          Get all products

GET	            /api/products/{id}	      Get product by ID

POST	          /api/products		          Create product

PUT	            /api/products/{id}	      Update product

DELETE	        /api/products/{id}	      Delete product

GET	            /api/products/{keyword}	  Get product by Name

How to Run
- Clone the repository
- Open in Visual Studio
- Run migration:
  Update-Database
- Press F5 to run

Author
Pascua, Emilyn
