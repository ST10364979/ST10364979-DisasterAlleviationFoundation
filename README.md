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

## 📁 Project Structure

