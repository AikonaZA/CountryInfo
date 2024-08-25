# CountryInfo Project

## Overview

The CountryInfo project consists of multiple layers, each encapsulated in its own project. These layers are:

1. **CountryInfo.Core**: Contains the core domain models and enums shared across the application.
2. **CountryInfo.Shared**: Houses shared DTOs (Data Transfer Objects) that are used for communication between the API and the front-end.
3. **CountryInfo.Infrastructure**: Contains infrastructure-related services, such as data access and external API integrations.
4. **CountryInfo.Application**: Includes business logic and services that interact with the domain models and infrastructure.
5. **CountryInfo.API**: An ASP.NET Core Web API that serves as the backend for managing country data, handling HTTP requests, and interacting with the application layer.
6. **CountryInfo.Web**: A Blazor WebAssembly front-end that interacts with the API to display country information and provide a user interface.

This document explains how to set up both the `CountryInfo.API` and `CountryInfo.Web` projects to run simultaneously in Visual Studio for testing and development.

## Multi-Startup Configuration in Visual Studio

To test the functionality of both the `CountryInfo.API` and `CountryInfo.Web` projects simultaneously, follow these steps:

### Step 1: Open the Solution in Visual Studio

- Open the solution that contains all the CountryInfo projects.

### Step 2: Set Up Multi-Startup Projects

1. **Right-click on the solution** in the Solution Explorer.
2. Select **"Configure Startup Projects..."** from the context menu.
3. In the dialog that appears:
   - Choose **"Multiple startup projects"**.
   - Set the **Action** for both `CountryInfo.API` and `CountryInfo.Web` to **"Start"**.
4. Click **Apply** then **OK** to save the configuration.

### Step 3: Run the Solution

- Press **F5** or click the **Start** button in Visual Studio to run both the `CountryInfo.API` and `CountryInfo.Web` projects simultaneously.
- This will start the API server and the Blazor WebAssembly client, allowing you to test the full functionality of the application.

## Implementation Notes

### Following Best Practices

I made every effort to adhere to the overall objectives and instructions for this project, implementing best practices where possible. This includes:

- **Separation of Concerns**: The application is divided into distinct layers and projects, ensuring that each layer is responsible for a specific part of the application’s functionality.
  - **Core Layer**: Handles domain models and shared enums.
  - **Shared Layer**: Provides DTOs for communication between the API and the front-end.
  - **Infrastructure Layer**: Manages data access and external API services.
  - **Application Layer**: Implements business logic and service management.
  - **API Layer**: Manages HTTP requests and interacts with the application layer.
  - **Web Layer**: Provides the Blazor WebAssembly-based user interface.
- **Modularity**: The codebase is structured to ensure maintainability and reusability.

### Areas for Improvement

- **Unit Testing**: I did not implement unit tests for the various components in this project. Adding unit tests would significantly improve the robustness and reliability of the application.
- **Null Reference Warnings**: I did not exhaustively review or resolve all compiler warnings related to potential null reference issues. Future improvements should address these warnings to enhance code safety and stability.

## Conclusion

This project is a demonstration of a basic yet functional full-stack application using ASP.NET Core and Blazor WebAssembly. While it meets the core requirements, there is always room for further refinement, especially in the areas of testing and error handling.

Feel free to explore the code, and I welcome any feedback or suggestions for further improvements.
