# Project Description

This project is an API application that performs email sending and stores sent emails and email addresses in a database. It provides the capability to access all your emails from a single location, even if your email address changes.

# Used Technologies
- ASP.NET API
- N Layer Architecture
- Generic Repository Pattern 
- Unit Of Work
- Entity Framework Core
- SQL Server
- Fluent Validation
- AutoMapper
- MailKit
- MimeKit

# Database Diagram

![DatabaseDiagram](https://www.serkanisik.com/wp-content/uploads/2023/09/mailapp.png)

# API Endpoint Definitions

**EmailAddresses**

| **HTTP Methods** | **Endpoints** | **Explanation** |
| --- | --- | --- |
| `GET`| `/api/EmailAddresses/GetAll` | Retrieve all email addresses. |
| `GET`| `/api/EmailAddresses/GetAll/EmailAddressWithEmailLogs/{emailAddressId}` | Retrieve details of a specific email address along with its email logs. |
| `GET`| `/api/EmailAddresses/GetById/{id}` | Retrieve a specific email address by ID. |
| `POST`| `/api/EmailAddresses/Create` | Create a new email address. | 
| `PUT`| `/api/EmailAddresses/Update` | Update an email address. | 
| `DELETE`| `/api/EmailAddresses/Delete/{id}` | Delete a specific email address. | 


**EmailLogs**

| **HTTP Methods** | **Endpoints** | **Explanation** |
| --- | --- | --- |
| `GET`| `/api/EmailLogs/GetAll` | Retrieve all email logs. | 
| `GET`| `/api/EmailLogs/GetById/{id}` | Retrieve a specific email log by ID. | 
| `GET`| `/api/EmailLogs/GetAll/EmailLogsWithEmailAddress` | Retrieve email logs along with their email addresses. | 
| `DELETE`| `/api/EmailLogs/Delete/{id}` | Delete a specific email log. | 



**SendEmail** 

| **HTTP Methods** | **Endpoints** | **Explanation** |
| --- | --- | --- |
| `POST`| `/api/SendEmail` | Endpoint for sending an email. | 

# Data Dictionary

**EmailAdresses Table**

| **Variable Name** | **Data Type**
| --- | --- |
| Id | int | 
| Email | nvarchar(64) |
| CreatedDate | datetime2(7) |
| UpdatedDate | datetime2(7) |

**EmailLogs Table**

| **Variable Name** | **Data Type**
| --- | --- |
| Id | int |
| Subject | nvarchar(255) |
| Body | nvarchar(max) |
| EmailAddressId | int |
| CreatedDate | datetime2(7) |