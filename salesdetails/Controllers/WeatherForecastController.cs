using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using salesdetails.Model;
using System.Data;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace salesdetails.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("SaveCustomer")]
        public ActionResult saveCustomer(saveCustomerRequest Request)
        {
            try
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\interview\\salesdetails\\DatabaseDetails\\Database1.mdf;Integrated Security=True"; //ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("saveCustomer", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@CustomerId", Request.CustomerId);
                        cmd.Parameters.AddWithValue("@CustomerName", Request.CustomerName);
                        cmd.Parameters.AddWithValue("@CustomerAddress", Request.CustomerAddress);
                        cmd.Parameters.AddWithValue("@CustomerEmail", Request.CustomerEmail);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();


                    }
                }
                return Ok("Customer saved successfully");
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        [HttpPost("SaveProduct")]
        public ActionResult saveProduct(saveProductRequest Request)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\interview\\salesdetails\\DatabaseDetails\\Database1.mdf;Integrated Security=True"; //ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("saveProduct", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@ProductId", Request.ProductId);
                    cmd.Parameters.AddWithValue("@ProductName", Request.ProductName);
                    cmd.Parameters.AddWithValue("@ProductDescription", Request.ProductDescription);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                }
            }
            return Ok("SaveProduct saved successfully");
        }

        [HttpPost("SaveCustomerdetails")]
        public ActionResult SaveCustomerdetails([FromBody]saveCustomerproductRequest Request)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\interview\\salesdetails\\DatabaseDetails\\Database1.mdf;Integrated Security=True"; //ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;
            DateTime date = Convert.ToDateTime(Request.DateOfSale);
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("savecustomerdetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@OrderId", Request.OrderId);

                    cmd.Parameters.AddWithValue("@ProductId", Request.ProductId);
                    cmd.Parameters.AddWithValue("@CustomerId", Request.customerId);
                    cmd.Parameters.AddWithValue("@ProductName", Request.ProductName);
                    cmd.Parameters.AddWithValue("@Category", Request.Category);
                    cmd.Parameters.AddWithValue("@Region", Request.Region);
                    cmd.Parameters.AddWithValue("@DateOfSale", date);
                    cmd.Parameters.AddWithValue("@QualitySold", Request.QualitySold);
                    cmd.Parameters.AddWithValue("@UnitPrice", Request.UnitPrice);
                    cmd.Parameters.AddWithValue("@Discount", Request.Discount);
                    cmd.Parameters.AddWithValue("@ShippingCost", Request.ShippingCost);
                    cmd.Parameters.AddWithValue("@PaymentMetod", Request.PaymentMethod);
                    cmd.Parameters.AddWithValue("@CustomerName", Request.CustomerName);
                    cmd.Parameters.AddWithValue("@CustomerEmail", Request.CustomerEmail);
                    cmd.Parameters.AddWithValue("@CustomerAddress", Request.CustomerAddress);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                }
            }
            return Ok("SaveCustomerdetails saved successfully");
        }


        [HttpPost("GetCustomerDetails")]
        public ActionResult GetCustomerDetails([FromBody] getCustomerproductRequest Request)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\interview\\salesdetails\\DatabaseDetails\\Database1.mdf;Integrated Security=True"; //ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;

            var model = new saveCustomerproductRequest();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.GetCustomerdetails", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@OrderId", Request.OrderId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            model = new saveCustomerproductRequest
                            {
                                OrderId = (int)reader.GetInt64(reader.GetOrdinal("OrderId")),
                                ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                                CustomerName = reader.GetString(reader.GetOrdinal("CustomerName"))
                            };
                        }
                    }
                }
            }
            return new OkObjectResult(model);

            
        }


        [HttpGet("TotalNoOFOrdersAndcustomerperday")]
        public ActionResult GetCustomerAnalysis()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\interview\\salesdetails\\DatabaseDetails\\Database1.mdf;Integrated Security=True"; //ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;

            var model = new List<totalorderperday>();
            var value = new totalorderperday();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.GetCustomerAnalysis", connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model.Add(new totalorderperday
                            {
                                OrderId = (int)reader.GetInt64(reader.GetOrdinal("OrderId")),
                                ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                                CustomerName = reader.GetString(reader.GetOrdinal("CustomerName")),
                            });
                        }
                    }
                }
            }
            return new OkObjectResult(model);


        }


        [HttpGet("GetTotalcustomer")]

        public ActionResult GetTotalcustomer()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\interview\\salesdetails\\DatabaseDetails\\Database1.mdf;Integrated Security=True"; //ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;

            var model = new List<saveCustomerRequest>();
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.getcustomer", connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            model.Add(new saveCustomerRequest
                            {
                                CustomerId = reader.GetString(reader.GetOrdinal("CustomerId")),
                                CustomerAddress = reader.GetString(reader.GetOrdinal("CustomerAddress")),
                                CustomerEmail = reader.GetString(reader.GetOrdinal("CustomerEmail")),
                                CustomerName = reader.GetString(reader.GetOrdinal("CustomerName"))
                            });
                        }
                    }
                }
            }
            return new OkObjectResult(model);
        }
    }
}
