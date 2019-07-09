# CarsApp
Cars app

PRE-REQUISITE:
- MS Visual Studio 2017 (Community edition is OK)

SOLUTION OVERVIEW:
- CarsApp.Client - Client app (ASP.NET core Razor)
- CarsApp.Client.ApiClient - Business logic for client app
- CarsApp.Client.ApiClient.Test - Unit test for client app business logic
- CarsApp.Models - Data model
- CarsApp.DAL - Data access layer
- CarsApp.MockApi - Mock Api of Kloud hosted Api
- CarsApp.Services - Mock Api service layer

HOW TO BUILD:
1) Open CarsApp/CarsApp.sln
2) Compile solution
3) Resolve any Nuget dependency

HOW TO RUN:
- CarsApp (http://localhost:8393) OR DEBUG mode (http://localhost:8394)
- MockApi (http://localhost:15558/api/cars) OR DEBUG mode (http://localhost:15559/api/cars)
