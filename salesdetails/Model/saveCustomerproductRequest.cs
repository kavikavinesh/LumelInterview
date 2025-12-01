using System.Reflection.PortableExecutable;

namespace salesdetails.Model;

public class saveCustomerproductRequest
{
    public int OrderId { get; set; }
    public String ProductId { get; set; }
    public String customerId { get; set; }
    public String ProductName { get; set; }
    public String Category { get; set; }
    public String Region { get; set; }
    public String DateOfSale { get; set; }
    public String QualitySold { get; set; }
    public String UnitPrice { get; set; }
    public String Discount { get; set; }
    public String ShippingCost { get; set; }
    public String PaymentMethod { get; set; }
    public String CustomerName { get; set; }
    public String CustomerEmail { get; set; }
    public String CustomerAddress { get; set; }
}

public class getCustomerproductRequest
{
    public int OrderId { get; set; }
}

public class totalorderperday
{
    public int OrderId { get; set; }
    public String CustomerName { get; set; }
    public String ProductName { get; set; }

}
