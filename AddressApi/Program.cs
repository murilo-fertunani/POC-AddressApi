using Microsoft.EntityFrameworkCore;
using AddressApi;
using AddressApi.DAL.Contexts;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql("Host=localhost;Port=5433;Database=addressapi;Username=postgres;Password=postgres"));
builder.Services.AddMassTransit(x => x.UsingRabbitMq());
builder.Services.AddDependencyInjections();
builder.Services.AddHttpClient();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper();

var app = builder.Build();

app.UseSwagger();
app.UseAddressController();
app.UseSwaggerUI(u =>
    {
        u.SwaggerEndpoint(string.Format("/swagger/v1/swagger.json"), string.Format("AddressApi V1"));
        u.RoutePrefix = string.Empty;
    });

app.Run();
