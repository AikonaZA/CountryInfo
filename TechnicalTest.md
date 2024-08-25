# Technical Assessment: Country Information Web Application

## Project Overview

The goal of this project is to create an ASP.NET web application that displays information about countries, regions, and subregions using the [REST Countries API](https://restcountries.com/). The application should feature a single page containing a table with available countries, and allow users to interact with this data to view more detailed information.

## Requirements

### 1. Main Table

- **Display**: The main table should list all countries with the following information:
  - Country Name
  - Region
  - Subregion
- **Default View**: All countries should be displayed by default in the table.

### 2. Country Details

- **Interaction**: If the user clicks on a country name in the table, display the following details:
  - Country Name
  - Capital City
  - Total Population
  - Official Currencies
  - Official Languages
  - Neighboring Countries/Borders
    - If the user clicks on one of the neighboring countries, the information for that country should be displayed.

### 3. Region Details

- **Interaction**: If the user clicks on a region in the table, display the following details:
  - Region Name
  - Total Population of the Region
  - List of Countries within the Region
    - If the user clicks on one of these countries, the information for that country should be displayed.
  - List of Subregions within the Region
    - If the user clicks on one of these subregions, the information for that subregion should be displayed.

### 4. Subregion Details (Optional)

- **Interaction**: If the user clicks on a subregion in the table, display the following details:
  - Subregion Name
  - Total Population of the Subregion
  - The Region it belongs to
    - If the user clicks on the region, the information for that region should be displayed.
  - List of Countries within the Subregion
    - If the user clicks on one of these countries, the information for that country should be displayed.

## Technical Requirements

- **Data Source**: All data should be sourced from the [REST Countries API](https://restcountries.com/) and called from the server. No direct API calls from the front-end.
- **Front-end Framework**: Use any front-end framework of your choice to render the UI.
- **NuGet Packages**: Welcome to use any NuGet packages necessary for the project.

## Evaluation Criteria

- **Coding Practices**: Evaluation of the quality of code, including adherence to best practices.
- **Modularity**: Emphasis on the creation of maintainable and reusable components.
- **Bonus Points**:
  - Implementing server-side caching.
  - Implementing pagination for the table.
  - Implementing search/filter functionality for the table.

## Submission

- **Git Repository**: House the project in a Git repository and send the link to the repository once the project is completed.

---
