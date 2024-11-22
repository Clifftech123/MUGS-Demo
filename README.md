# Microsoft User Group Ghana Summit 2024

Welcome to the sample project for the Microsoft User Group Ghana Summit 2024. This project showcases the integration and usage of various modern technologies and frameworks to build a robust and scalable application.

## Overview

This project demonstrates how to leverage the following technologies:

- **.NET 9**: The latest version of the .NET framework, providing improved performance, new features, and enhancements.
- **C#**: A modern, object-oriented programming language designed for building a wide range of applications.
- **Azure Container Apps**: A fully managed serverless container service for building and deploying modern applications and microservices.
- **.NET Aspire**: A set of libraries and tools to streamline the development of .NET applications with best practices.
- **Azure Redis Cache**: A secure, dedicated cache service managed by Microsoft, providing high throughput and low latency data access.
- **Deployment to Azure Container Apps**: Step-by-step guidance on deploying a .NET 9 application to Azure Container Apps.

## Features

- **Country Data API**: Provides endpoints to fetch country-related data such as country codes, phone codes, regions, and flags.
- **Caching with Redis**: Implements caching strategies using Azure Redis Cache to improve performance and reduce latency.
- **Health Checks**: Includes health check endpoints to monitor the application's health and readiness.
- **OpenTelemetry**: Integrates OpenTelemetry for distributed tracing and monitoring.
- **Service Discovery**: Utilizes service discovery for dynamic service registration and resolution.

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/)
- [Azure Subscription](https://azure.microsoft.com/en-us/free/)

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/your-repo/MUGS2024dEMO.git
    cd MUGS2024dEMO
    ```

2. Restore the dependencies:
    ```sh
    dotnet restore
    ```

3. Build the solution:
    ```sh
    dotnet build
    ```

### Running the Application

1. Start the API service:
    ```sh
    cd src/MUGS2024dEMO.ApiService
    dotnet run
    ```

2. Start the web application:
    ```sh
    cd src/MUGS2024dEMO.Web
    dotnet run
    ```

### Deployment

Follow the steps in the [deployment guide](docs/deployment.md) to deploy the application to Azure Container Apps.

