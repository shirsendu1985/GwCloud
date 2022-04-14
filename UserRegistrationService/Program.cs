using Microsoft.EntityFrameworkCore;
using UserRegistrationService.Data;
using UserRegistrationService.Repository.DataProvider;
using UserRegistrationService.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CustomerDataContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerDataContext")));
builder.Services.AddTransient<ICustomerContract, CustomerDataprovider>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
