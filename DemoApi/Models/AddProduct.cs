namespace DemoApi.Models;

public class AddProduct
{
    public string Name { get; set; }
    public int Qnty { get; set; }
    public decimal Price { get; set; }
}


public class UpdateProduct
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public int Qnty { get; set; }
    public decimal Price { get; set; }
}

