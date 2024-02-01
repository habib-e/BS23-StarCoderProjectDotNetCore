# BS23-StarCoderProjectDotNetCore

**Setup Instructions:**

**Change Database Connection String:**
Navigate to the Data folder in your project and locate the ApplicationDbContext.cs file. Inside this file, find the OnConfiguring method and update the connection string with the appropriate values for your MySQL database.

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
     optionsBuilder.UseMySql("your_connection_string_here");
}

**Generate Migrations:**
Open the Package Manager Console in Visual Studio. Run the following commands to create and apply migrations:

Add-Migration InitialMigration
Update-Database

This will apply the initial migration to set up your database.

**Build and Run:**
Build your project and run it. Ensure that the database is created and migrated successfully.
