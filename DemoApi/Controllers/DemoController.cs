using Azure.Core;
using DemoApi.Data;
using DemoApi.Entities;
using DemoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DemoController : ControllerBase
{
    [HttpGet]
    public List<Product> GetProducts()
    {
        var context = new AppDbContext();

        context.Database.EnsureCreated();

        return context.Products.ToList();
    }

    [HttpPost]
    public void AddProduct(AddProduct request)
    {
        var context = new AppDbContext();

        context.Database.EnsureCreated();

        var product = new Product()
        {
            Name = request.Name,
            Price = request.Price,
            Qnty = request.Qnty,
        };

        context.Products.Add(product);

        context.SaveChanges();
    }

    [HttpPut]
    public void UpdateProduct(UpdateProduct request)
    {
        var context = new AppDbContext();

        context.Database.EnsureCreated();

        var product = context.Products.FirstOrDefault(i => i.Id == request.ProductId);

        product.Name = request.Name;
        product.Qnty = request.Qnty;
        product.Price = request.Price;

        context.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void DeleteProduct(int id)
    {
        var context = new AppDbContext();

        context.Database.EnsureCreated();

        var product = context.Products.FirstOrDefault(i => i.Id == id);

        context.Products.Remove(product);

        context.SaveChanges();
    }
}
