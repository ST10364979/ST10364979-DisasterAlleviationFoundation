# Disaster Alleviation Foundation 

A lightweight ASP.NET Core MVC app that helps communities report incidents, coordinate donations, and mobilize volunteers.


Features

- User Accounts (Identity)
  - Register / Login / Logout
  - Auth-only forms & actions

- Disaster Incident Reporting
  - Create, view, edit, delete incidents
  - Fields: Title, Description, Location, OccurredAt, Severity, Status

- Resource Donations
  - Log donations with Type, Quantity, Status (Pledged → Received → Distributed)
  - Donation details + notes

- Volunteer Management
  - Create tasks with time, location, slots
  - Users can sign up; personal “My Signups” view

- UI/Theme
  - Custom blue gradient + “glass” cards
  - Responsive layout, accessible controls


Tech Stack

- ASP.NET Core MVC (.NET 7/8)
- Entity Framework Core
- SQLite (local dev database)
- ASP.NET Core Identity
- Bootstrap 5 
- Azure DevOps (Repos + Pipelines)

Project Structure

DisasterAlleviationFoundation/
├─ Controllers/
│ ├─ AccountController.cs
│ ├─ IncidentsController.cs
│ ├─ DonationsController.cs
│ └─ VolunteersController.cs
├─ Data/
│ ├─ ApplicationDbContext.cs
│ └─ Migrations/ (EF Core migrations)
├─ Models/
│ ├─ Incident.cs
│ ├─ Donation.cs
│ └─ VolunteerTask.cs 
│ └─ ViewModels/ (Login/Register etc.)
├─ Views/
│ ├─ Shared/ (_Layout.cshtml, _ViewImports.cshtml, _ViewStart.cshtml)
│ ├─ Home/ (Index.cshtml)
│ ├─ Account/ (Login.cshtml, Register.cshtml)
│ ├─ Incidents/ (Index/Create/Edit/Details/Delete.cshtml)
│ ├─ Donations/ (Index/Create/Details.cshtml)
│ └─ Volunteers/ (Index/Create/MySignups.cshtml)
├─ wwwroot/
│ ├─ css/site.css
│ └─ lib/ 
├─ appsettings.json
├─ Program.cs
└─ azure-pipelines.yml
