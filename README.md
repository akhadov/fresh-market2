# FreshMarket E-Commerce Application
<!-- TOC -->
- [Fresh Market](#freshMarket-e-commerce-application)
    - [Overview](#overview)
    - [✨ Features](#-features)
    - [Getting Started](#getting-started)
        - [Running the Solution](#running-the-solution)
<!-- TOC -->

## Overview
FreshMarket was designed to solve the most important business challenges from the world of digital shopping. The goal is to provide the platform with:
* The high performance application to handle temporary and permanent traffic overloads,
* Highly advanced e-commerce platform with unlimited possibilities of integration with existing third-party softwares
* Fast development with modern codebase
* Scalable e-commerce platform to grow with the business

## ✨ Features

- 🌐 Minimal Endpoints
- 🔑 Global Exception Handling
- 📝 OpenAPI/Swagger
- 🗄️ Entity Framework Core
- 🧩 Specification Pattern
- 🔀 CQRS - for separation of concerns
- 📦 MediatR - for decoupling your application
- 📦 FluentValidation - for validating requests
- 🆔 Strongly Typed IDs - to combat primitive obsession

## Getting Started

The following prerequisites are required to build and run the solution:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (latest version)

Clone the repository to get start [fresh-market2](https://github.com/akhadov/fresh-market2):
```
git clone https://github.com/akhadov/fresh-market2.git
```
Restore the project at the root directory:
```bash
dotnet restore
```
Next, build the solution by running:
```bash
dotnet build
```

## Running the Solution

1. Start dockerized PostgreSQL Server

```bash
docker compose up
```

2. Run the solution

```bash
dotnet run
```

