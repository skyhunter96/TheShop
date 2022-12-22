using MediatR;
using Shop.Application.Interfaces;
using Shop.Infrastructure.Services;
using ILogger = Shop.Application.Interfaces.ILogger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(typeof(ISupplierService), typeof(CachedSupplierService));
builder.Services.AddTransient(typeof(ILogger), typeof(Logger));
builder.Services.AddTransient(typeof(IDealer), typeof(DealerService));
builder.Services.AddTransient(typeof(IDatabaseDriver), typeof(DbService));
builder.Services.AddTransient(typeof(IWarehouseService), typeof(WarehouseService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "PlaceInfo Services"));
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
