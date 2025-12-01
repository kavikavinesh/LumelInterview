This project is done for the Lumel Interview as per ask please refer the information breid about the project 

Technology used
BackEnd: ASP.NET 
Language: C#
DB : SQL 
Tool: Microsoft SQL Server(Server Explorer)

for this project i used .Net version 8 and create a two project ASP.net WEB API for API intergration and routing and another console for Databased data please refer the below image of soution explorer
<img width="828" height="560" alt="image" src="https://github.com/user-attachments/assets/8ef365c3-02ec-4163-ab55-5c2629eeef09" />

As said The database was created below screenshot represent the table and store procedure creation 
<img width="610" height="335" alt="image" src="https://github.com/user-attachments/assets/67886026-9fd9-4385-b1c2-09c7bdda24c2" />

post creation of DB by using the db connection string the connect was established between API and database
<img width="1275" height="245" alt="image" src="https://github.com/user-attachments/assets/dce02f3b-0f5b-4265-8b4c-1a1884ee0024" />

post connction established we have create a model for all the based on that the value is request to DB and value is fetched 
for the API end point we use swagger to request it the screenshot of swagger is attached below 
<img width="1886" height="961" alt="image" src="https://github.com/user-attachments/assets/35687bd9-58cf-4fef-b6e0-97e49e7f15f2" />

totaly i created a 7 store procedure in Database as mentioned in above Screenshot and 6 end point to access it 

As in core Analysis it mentioned out 4 need to do for one in this i choose **Customer Analysis:** as per ask- 
**Total Number of Customers:** (Within a date range)
- **Total Number of Orders:** (Within a date range)
- **Average Order Value:** (Within a date range)


  this is delivered 
  please find the below end point and its use 
1)
request Url:https://localhost:7128/WeatherForecast/SaveCustomer
request Body 
{
  "customerId": "3",
  "customerName": "park",
  "customerAddress": "Bangalore",
  "customerEmail": "park12@gmail.com"
}

descritption: to save a seperate customer

2)
request Url: https://localhost:7128/WeatherForecast/SaveProduct
Request body:
{
  "productId": 1004,
  "productName": "bike",
  "productDescription": "Description of bike"
}
descritption: to save a seperate product


3)
Request Url: https://localhost:7128/WeatherForecast/SaveCustomerdetails
  Request Body:
  {
  "orderId": 1,
  "productId": "1001",
  "customerId": "2",
  "productName": "Art",
  "category": "Art",
  "region": "India",
  "dateOfSale": "12/01/2025",
  "qualitySold": "2",
  "unitPrice": "10,000",
  "discount": "10%",
  "shippingCost": "500",
  "paymentMethod": "Cash",
  "customerName": "Rohith",
  "customerEmail": "Rohith@gmail.com",
  "customerAddress": "chennai"
}

4)
Request Url: https://localhost:7128/WeatherForecast/GetCustomerDetails

request body: {
  "orderId": 1
}

Response:

{
  "orderId": 1,
  "productId": "1001",
  "customerId": "2",
  "productName": "Art",
  "category": "Art",
  "region": "India",
  "dateOfSale": null,
  "qualitySold": null,
  "unitPrice": "10,000",
  "discount": "10%",
  "shippingCost": "500",
  "paymentMethod": "Cash",
  "customerName": "Rohith",
  "customerEmail": "Rohith@gmail.com",
  "customerAddress": "chennai"
}


Description : based on the orderId we can take the details of that particular order 


5).
As ask od the **Customer Analysis** this API will return the - **Total Number of Customers:** (Within a date range)
- **Total Number of Orders:** (Within a date range) please find the below screenshot for the API 
<img width="1821" height="834" alt="image" src="https://github.com/user-attachments/assets/339d1aa6-5d85-4e37-983e-14a713ed86f9" />


request url: https://localhost:7128/WeatherForecast/TotalNoOFOrdersAndcustomerperday

response :
[
  {
    "orderId": 1,
    "customerName": "Rohith",
    "productName": "Art"
  },
  {
    "orderId": 2,
    "customerName": "KUMAR",
    "productName": "Arts"
  }
]

6)
request url :
https://localhost:7128/WeatherForecast/GetTotalcustomer

response: 
[
  {
    "customerId": "1",
    "customerName": "kavi",
    "customerAddress": "abc",
    "customerEmail": "abc@gmail.com"
  },
  {
    "customerId": "2",
    "customerName": "Rohith",
    "customerAddress": "Chennai",
    "customerEmail": "Rohith@gmail.com"
  },
  {
    "customerId": "3",
    "customerName": "park",
    "customerAddress": "Bangalore",
    "customerEmail": "park12@gmail.com"
  }
]


description this will return all the customwe in out data base

  
