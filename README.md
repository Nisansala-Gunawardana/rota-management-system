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
NurserySystem-APIGateway - Routes requests from frontend to microservices
NurserySystem-AttendenceAPI- Handles CRUD operations for Rota, Employee shifts,Locations
NurserySystem-HRWebAPI - Handles CRUD operations for Employee,ContractDetails
NueserySystem-UI - Angular application for viewing and editing rotas
HRWebAPI_Test/AttendenceAPI-TestProject - Test cases for test the logic 

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
