<h1 font-size: 48px;">Api Documentation</h1>

The API documentation is available through Swagger UI at.

![image](https://github.com/emreturan00/case_study/assets/93795815/ebd28f51-5533-456b-88df-a683a3f5472d)

![image](https://github.com/emreturan00/case_study/assets/93795815/5fd2ad55-4d60-48f5-b1bf-3765449b0f65)





<h1 style="text-align: center; font-size: 48px;">How To Run</h1>

<h2 style="text-align: center; font-size: 36px;">My Project</h2>

<h3 style="text-align: center; font-size: 30px;">Setting Up the Development Environment</h3>

<p style="text-align: center; font-size: 24px;">
1. Install .NET 6.0<br>
2. Install Visual Studio 2022<br>
3. Install Docker<br>
4. Install RabbitMQ<br>
5. Clone the repository: <a href="https://github.com/emreturan00/case_study">https://github.com/emreturan00/case_study</a>
</p>

<h3 style="text-align: center; font-size: 30px;">Technologies Used</h3>

<p style="text-align: center; font-size: 24px;">
- .NET 6.0: The project is built with .NET 6.0<br>
- Entity Framework Core: This is used as the Object-Relational Mapper (ORM) to interact with the database using .NET objects.<br>
- In-Memory Database: For development and testing, the project uses an in-memory database provided by Entity Framework Core.<br>
- Docker: Docker is used to containerize the application and its dependencies.<br>
- RabbitMQ: This is used as the message broker for asynchronous messaging.
</p>

<h3 style="text-align: center; font-size: 30px;">Architecture</h3>

<p style="text-align: center; font-size: 24px;">
The project follows the REST architectural style for the API design. This means that it uses standard HTTP methods like GET, POST, PUT, DELETE to perform operations on resources. The API is stateless, and it communicates with clients using JSON.
</p>

# High-Level Architecture Documentation

## Overview

This project is a .NET 6.0 application that provides a RESTful API for managing customers and their bank accounts. It follows a layered architecture pattern, with separate layers for HTTP controllers, services, and repositories. The application uses Entity Framework Core for data access, with an in-memory database for simplicity.

## Components

### Controllers

Controllers handle HTTP requests and responses. They use the services to perform operations and return the results to the client. The controllers in this project are:

- **CustomerController**: Handles operations related to customers, such as creating, updating, retrieving, and deleting customers.
- **AccountController**: Handles operations related to accounts, such as adding an account to a customer, retrieving an account, and updating an account by a customer.
- **TransferController**: Handles money transfer operations between accounts.

### Services

Services contain the business logic of the application. They use the repositories to access data and perform operations on it. The services in this project are:

- **CustomerService**: Provides operations related to customers.
- **AccountService**: Provides operations related to accounts.
- **TransferService**: Provides operations related to money transfers.

### Repositories

Repositories handle data access. They use Entity Framework Core to interact with the database. The repositories in this project are:

- **CustomerRepository**: Provides data access for customers.
- **AccountRepository**: Provides data access for accounts.

### Models

Models represent the data in the application. The models in this project are:

- **Customer**: Represents a customer, with properties for the customer ID and name, and a collection of accounts.
- **Account**: Represents a bank account, with properties for the account ID, account number, balance, and customer ID.

### Data Transfer Objects (DTOs)

DTOs are used to transfer data between the client and the server. The DTOs in this project are:

- **CustomerDto**: Represents a customer for data transfer, with properties for the customer ID, name, and a list of account DTOs.
- **AccountDto**: Represents an account for data transfer, with properties for the account ID, account number, balance, and customer ID.
- **TransferDto**: Represents a money transfer, with properties for the source account ID, destination account ID, and transfer amount.

### Message Queue

The **MessageQueuePublisher** class is used to publish messages to a RabbitMQ message queue. This is used for asynchronous communication in the application.

## Infrastructure

The application is containerized using Docker, with a Dockerfile that defines how to build the Docker image. The application is also designed to be deployed on a Kubernetes cluster, with a `deployment.yaml` file that defines the Kubernetes Deployment and a `service.yaml` file that defines the Kubernetes Service.

### Database

The application uses an in-memory database provided by Entity Framework Core. The **AppDbContext** class is the Entity Framework database context, with `DbSet` properties for customers and accounts.

## External Dependencies

The application uses RabbitMQ for asynchronous messaging. The **MessageQueuePublisher** class uses the RabbitMQ .NET client to publish messages to a RabbitMQ server.

