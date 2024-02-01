# BS23-StarCoderProjectDotNetCore<br>

**Setup Instructions:**<br>

**Change Database Connection String:**<br>
Navigate to the Data folder in your project and locate the ApplicationDbContext.cs file.<br> Inside this file, find the OnConfiguring method and update the connection string with the appropriate values for your MySQL database.

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
     optionsBuilder.UseMySql("your_connection_string_here");
}

**Generate Migrations:**<br>
Open the Package Manager Console in Visual Studio. Run the following commands to create and apply migrations:

Add-Migration InitialMigration
Update-Database

This will apply the initial migration to set up your database.

**Build and Run:**<br>
Build your project and run it. Ensure that the database is created and migrated successfully.

**API Documentation**<br>

AuthController
Register User
Registers a new user.

Endpoint: POST /api/Auth/Register

Request:

Content-Type: application/json
Body: UserRegistrationModel

{
  "UserName": "string",
  "Password": "string",
  "Email": "string"
}
Response:

Status Code: 200 OK
Body:

{
  "Username": "string",
  "Message": "Congrats! You have been Successfully Registered"
}
Login User
Logs in an existing user.

Endpoint: POST /api/Auth/Login

Request:

Content-Type: application/json
Body: UserLoginModel

{
  "Username": "string",
  "Password": "string"
}
Response:

Status Code: 200 OK
Body:

{
  "token": "string",
  "Username": "string"
}
TaskController
Create Task
Creates a new task.

Endpoint: POST /api/Task/Tasks

Authorization: Bearer Token Required

Request:

Content-Type: application/json
Body: TaskCreateModel

{
  "TaskName": "string",
  "Description": "string",
  "DueDate": "datetime"
}
Response:

Status Code: 200 OK
Body:

{
  "message": "Data created successfully"
}
Get All Tasks
Gets all tasks.

Endpoint: GET /api/Task/AllTasks
Authorization: Bearer Token with Admin Role Required
Response:
Status Code: 200 OK
Body: List of TaskRetrieveModel
Get User Tasks
Gets tasks specific to the authenticated user.

Endpoint: GET /api/Task/Tasks
Authorization: Bearer Token Required
Response:
Status Code: 200 OK
Body: List of TaskRetrieveModel
Update Task
Updates an existing task.

Endpoint: PUT /api/Task/Tasks?id={task-id}

Authorization: Bearer Token Required

Request:

Content-Type: application/json
Body: TaskCreateModel

{
  "TaskName": "string",
  "Description": "string",
  "DueDate": "datetime"
}
Response:

Status Code: 200 OK
Body:

{
  "Message": "Successfully Updated"
}
Delete Task
Deletes an existing task.

Endpoint: DELETE /api/Task/Tasks?id={task-id}

Authorization: Bearer Token Required

Response:

Status Code: 200 OK
Body:

{
  "Message": "Successfully Deleted"
}
WeatherForecastController
Get Weather Forecast
Gets a weather forecast.

Endpoint: GET /WeatherForecast/GetWeatherForecast
Response:
Status Code: 200 OK
Body: List of WeatherForecast
