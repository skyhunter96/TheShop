using MediatR;
using Vendor.Application.Interfaces;
using Vendor.Infrastructure.Services;
using ILogger = Vendor.Application.Interfaces.ILogger;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient(typeof(IDatabaseDriver), typeof(DatabaseDriver));
builder.Services.AddTransient(typeof(ILogger), typeof(Logger));
builder.Services.AddTransient(typeof(ISupplierService), typeof(SupplierService));

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
