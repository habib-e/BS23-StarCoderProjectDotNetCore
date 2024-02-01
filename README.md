# BS23-StarCoderProjectDotNetCore<br>

**Setup Instructions:**<br>

**Change Database Connection String:**<br>
Navigate to the Data folder in your project and locate the ApplicationDbContext.cs file.<br> Inside this file, find the OnConfiguring method and update the connection string with the appropriate values for your MySQL database.

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)<br>
{<br>
     optionsBuilder.UseMySql("your_connection_string_here");<br>
}<br>

**Generate Migrations:**<br>
Open the Package Manager Console in Visual Studio. Run the following commands to create and apply migrations:

Add-Migration InitialMigration<br>
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

{<br>
  "UserName": "string",<br>
  "Password": "string",<br>
  "Email": "string"<br>
}<br>
Response:

Status Code: 200 OK<br>
Body:<br>

{<br>
  "Username": "string",<br>
  "Message": "Congrats! You have been Successfully Registered"<br>
}<br>
Login User<br>
Logs in an existing user.<br>

Endpoint: POST /api/Auth/Login<br>

Request:<br>

Content-Type: application/json<br>
Body: UserLoginModel<br>

{<br>
  "Username": "string",<br>
  "Password": "string"<br>
}<br>
Response:<br>

Status Code: 200 OK<br>
Body:<br>

{<br>
  "token": "string",<br>
  "Username": "string"<br>
}<br>
TaskController<br>
Create Task<br>
Creates a new task.<br>

Endpoint: POST /api/Task/Tasks<br>

Authorization: Bearer Token Required<br>

Request:<br>

Content-Type: application/json<br>
Body: TaskCreateModel<br>

{<br>
  "TaskName": "string",<br>
  "Description": "string",<br>
  "DueDate": "datetime"<br>
}<br>
Response:<br>

Status Code: 200 OK<br>
Body:<br>

{<br>
  "message": "Data created successfully"<br>
}<br>
Get All Tasks<br>
Gets all tasks.<br>

Endpoint: GET /api/Task/AllTasks<br>
Authorization: Bearer Token with Admin Role Required<br>
Response:<br>
Status Code: 200 OK<br>
Body: List of TaskRetrieveModel<br>
Get User Tasks<br>
Gets tasks specific to the authenticated user.<br>

Endpoint: GET /api/Task/Tasks<br>
Authorization: Bearer Token Required<br>
Response:<br>
Status Code: 200 OK<br>
Body: List of TaskRetrieveModel<br>
Update Task<br>
Updates an existing task.<br>

Endpoint: PUT /api/Task/Tasks?id={task-id}<br>

Authorization: Bearer Token Required<br>

Request:<br>

Content-Type: application/json<br>
Body: TaskCreateModel<br>

{<br>
  "TaskName": "string",<br>
  "Description": "string",<br>
  "DueDate": "datetime"<br>
}<br>
Response:<br>

Status Code: 200 OK<br>
Body:<br>

{<br>
  "Message": "Successfully Updated"<br>
}<br>
Delete Task<br>
Deletes an existing task.<br>

Endpoint: DELETE /api/Task/Tasks?id={task-id}<br>

Authorization: Bearer Token Required<br>

Response:<br>

Status Code: 200 OK<br>
Body:<br>

{<br>
  "Message": "Successfully Deleted"<br>
}<br>
WeatherForecastController<br>
Get Weather Forecast<br>
Gets a weather forecast.<br>

Endpoint: GET /WeatherForecast/GetWeatherForecast<br>
Response:<br>
Status Code: 200 OK<br>
Body: List of WeatherForecast<br>
