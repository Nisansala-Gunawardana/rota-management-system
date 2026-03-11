# Rota Management System
A microservices-based rota management system for managing employee schedules, shifts, and day-offs. Built with ASP.NET Core, Ocelot API Gateway, and Angular 19.## Table of Contents
## Table of Contents
- [Project Overview](#project-overview)
- [Architecture](#architecture)
- [Features](#features)
- [Technology Stack](#technology-stack)
- [How to Run](#how-to-run)
- [Future Improvements](#future-improvements)
- [Author](#author)

## Project Overview

This system allows administrators to:
- Create and manage employee records and contracts
- Assign shifts and generate weekly rotas
- Handle permanent and bank staff shifts
- Integrate employee day-offs into rota planning
- Edit shifts through a responsive Angular UI
  
## Architecture
- NurserySystem-APIGateway - Routes requests from frontend to microservices
- NurserySystem-AttendenceAPI- Handles CRUD operations for Rota, Employee shifts,Locations
- NurserySystem-HRWebAPI - Handles CRUD operations for Employee,ContractDetails
- NueserySystem-UI - Angular application for viewing and editing rotas
- HRWebAPI_Test/AttendenceAPI-TestProject - Test cases for test the logic 

## Features
- Employee CRUD and contract management
- Weekly rota generation with automatic shift assignment
- Integration of permanent and bank staff shifts
- Day-off management for employees
- Editable rota table in Angular
  
## Technology Stack
- Backend: ASP.NET Core, C#, Repository Pattern
- Frontend: Angular 19, TypeScript, Bootstrap
- API Gateway: Ocelot
- Database: SQL Server

## How to Run
> Note: Some services may require database setup to run locally.

1. Clone the repository: https://github.com/Nisansala-Gunawardana/rota-management-system.git
2. Open each backend project in Visual Studio 2022
3. Restore NuGet packages
4. Configure database connection in `appsettings.json`
5. Run backend services
6. Open Rota.UI folder and run Angular frontend:
    npm install
    ng serve
7. Access frontend at http://localhost:4200
   
## Future Improvements
- JWT authentication for secure access
- CI/CD pipelines for automated deployment
- Hosting on Azure for cloud access
- Advanced reporting features

## Author
Nisansala Gunawardana – Full-stack .NET Developer
- Experienced in ASP.NET MVC/Core, C#, Web API, SQL Server, Angular
- Built real-world applications for healthcare, retail, and HR

GitHub: https://github.com/Nisansala-Gunawardana
LinkedIn: linkedin.com/in/nisansala-gunawardana-69a681239
