# Azure Functions PostgreSQL Binding

This binding allows you to do simple input and output binding queries using PostgreSQL from an Azure Function.

# Development

The **PostgreSQLExtension** project contains a Function App that utilizes the binding. To use it:

1. Create a PostgreSQL database.
1. Run the schema.sql file to build the database.
1. Include the following **local.settings.json** file.

	```JSON
	{
      "IsEncrypted": false,
      "Values": {
        "AzureWebJobsStorage": "UseDevelopmentStorage=true",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet",
        "PostgresConnection": "<postgresql_connection_string>"
      }
    }
	```