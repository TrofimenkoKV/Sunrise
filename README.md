prerequisites:
Mysql need to be installed;

1. Clone the project;
2. Go to "Sunrise" package;
3. Run in console "dotnet build"
4. Run in console "dotnet run" with params for databse in such order = server, port, schema, user, password. 
        For example: "dotnet run localhost 3306 dotnet root password"
5. To run tests go to "Sunrise.Test" package and run "dotnet test";

App Endpoints:

To get token:
        https://localhost:5001/api/token/

        Supports POST method;

        Expected body for POST:
        {
	   "password": "12534",
	   "user_name": "tllkihuest"
        }

For city info (token needed for requesting this endpoint):
        https://localhost:5001/api/cities

        Supports GET and POST methods;

        on GET retrieves all supported cities;

        on POST saves city to db;
        Expected body for POST:

        {
            "city": "Lviv",
            "latitude": 251.12,
            "longitude": 38.21
        }

For Sunrise info:
        https://localhost:5001/api/event-time/{cityname}
        Support GET method

        Supports query parameter "event_time" with possible values "All", "Sunrise", "Sunset" or 1,2,3 (case insensetive)
        
        Examples:
        https://localhost:5001/api/event-time/Lviv?event_time=2
        https://localhost:5001/api/event-time/Lviv?event_time=sunrise