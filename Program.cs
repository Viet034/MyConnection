using ConnectMySql.DB;
using ConnectMySql.Mapper;
using ConnectMySql.Mapper.Impl;
using ConnectMySql.Service;
using ConnectMySql.Service.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductMapper, ProductMapper>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerMapper, CustomerMapper>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IEmployeeMapper, EmployeeMapper>();
builder.Services.AddScoped<IEmployeeService, EmployeeService >();
builder.Services.AddScoped<IOrderMapper, OrderMapper>();
builder.Services.AddScoped<IOrderService, OrderService>();
var connectionStr = builder.Configuration.GetConnectionString("MyConnectionString");


builder.Services.AddDbContext<ApplicationDbContext>(o =>
    o.UseMySql(connectionStr, new MySqlServerVersion(new Version(8, 0, 33))));





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
