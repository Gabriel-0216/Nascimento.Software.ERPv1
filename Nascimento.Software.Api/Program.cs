using Domain.Entities.Buyer;
using Domain.Entities.Payments;
using Domain.Entities.Product;
using Domain.Entities.PurchaseRequest;
using Domain.Entities.Purchases;
using Infra.Context;
using Newtonsoft.Json;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson
    (options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepository<Products>, ProductRepository>();
builder.Services.AddScoped<IRepository<ProductStock>, ProductStockRepository>();
builder.Services.AddScoped<IRepository<Buyers>, BuyersRepository>();
builder.Services.AddScoped<IRepository<Purchase>, PurchaseRepository>();
builder.Services.AddScoped<IRepository<BoletoPayment>, BoletoPaymentRepository>();
builder.Services.AddScoped<IRepository<CreditCartPayment>, CreditCardPaymentRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
