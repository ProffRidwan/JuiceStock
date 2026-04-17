using FluentValidation;
using FluentValidation.AspNetCore;
using JuiceStock.Api.Contracts.Common;
using JuiceStock.Application.Customers;
using JuiceStock.Application.Products;
using JuiceStock.Application.Suppliers;
using JuiceStock.Infrastructure.Persistence;
using JuiceStock.Infrastructure.Persistence.Repositories;
using JuiceStock.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);



// Add services

builder.Services.AddControllers().AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<Program>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddDbContext<JuiceStockDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});
var app = builder.Build();


// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();