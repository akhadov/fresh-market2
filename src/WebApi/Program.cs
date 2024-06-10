using FreshMarket.Application;
using FreshMarket.Infrastructure;
using FreshMarket.WebApi;
using FreshMarket.WebApi.Extensions;
using FreshMarket.WebApi.Features;
using FreshMarket.WebApi.Infrastructure;
using WebApi.Features;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddWebApi(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddHttpContextAccessor();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRequestContextLogging();

app.UseExceptionHandler();

app.UseRouting();

app.MapCategoryEndpoints();
app.MapCustomerEndpoints();
app.MapProductEndpoints();
app.MapOrderEndpoints();
app.MapBlogPostEndpoints();

app.Run();

public partial class Program { }
