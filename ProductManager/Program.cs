using NuGet.Protocol.Core.Types;
using ProductManager;
using ProductManager.Data.Models;
using ProductManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

using (var client = new Context())
{
    var Order1 = new Orders()
    {
        CustomerId = 1233414,
        Amount = 20,
        
    };

    //DB Values Demonstration Example
    var product1 = new Products()
    {
        Name = "Пряники",
        Price = 50,
        Description = "Мятные",
        Amount = 1000,
    };

    var product2 = new Products()
    {
        Name = "Вафли",
        Price = 69,
        Description = "Сладкие",
        Amount = 1000,
    };

    var product3 = new Products()
    {
        Name = "Шоколад",
        Price = 20,
        Amount = 1000,
    };

    var product4 = new Products()
    {
        Name = "Конфеты",
        Price = 3,
        Description = "с начинкой",
        Amount = 2000,
    };

    var product5 = new Products()
    {
        Name = "Хлеб",
        Price = 24,
        Amount = 500,
    };

    client.Products.Add(product1);
    client.Products.Add(product2);
    client.Products.Add(product3);
    client.Products.Add(product4);
    client.Products.Add(product5);

    client.SaveChanges();
}

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
builder.Services.AddDbContext<Context>(options => options.UseSqlite(@"Data Source=ProductsDB.db;Cache=Shared"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
        

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
