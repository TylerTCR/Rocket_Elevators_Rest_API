# Rocket_Elevators_REST_API

The REST API uses C# with .NET Core.

### REST API Team
<strong>Arman Adibi</strong> and <strong>Tyler Calderon</strong>
</p>

### Retrieving and Modifying The Data
<ol>
   <li>Retrieving the current status of a specific Battery</li>
   <p>https://rocket-elevators-api.azurewebsites.net/battery/1</p>
   
   <li>Changing the status of a specific Battery</li>
   <p>https://rocket-elevators-api.azurewebsites.net/battery</p>
   <p>In Postman body: {"id": "1", "status": "Inactive" }</p>
   
   <li>Retrieving the current status of a specific Column:</li>
   <p>https://rocket-elevators-api.azurewebsites.net/column/1</p>
   
   <li>Changing the status of a specific Column:</li>
   <p>https://rocket-elevators-api.azurewebsites.net/column</p>
   <p>In Postman body: {"id": "1",  "status": "Inactive" }</p>
   
   <li>Retrieving the current status of a specific Elevator:</li>
   <p>https://rocket-elevators-api.azurewebsites.net/elevator/1</p>
   
   <li>Changing the status of a specific Elevator:</li>
   <p>https://rocket-elevators-api.azurewebsites.net/elevator</p>
   <p>In Postman body: {"id": "1",  "status": "Inactive" }</p>
   
   <li>Retrieving a list of Elevators that are not in operation at the time of the request</li>
   <p>https://rocket-elevators-api.azurewebsites.net/elevator/inactive</p>
   
   <li>Retrieving a list of Buildings that contain at least one battery, column or elevator requiring intervention</li>
   <p>https://rocket-elevators-api.azurewebsites.net/buildings</p>
   
   <li>Retrieving a list of Leads created in the last 30 days who have not yet become customers.</li>
   <p>https://rocket-elevators-api.azurewebsites.net/leads/recent</p>
</ol>
