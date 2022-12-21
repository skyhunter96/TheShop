using MediatR;
using System.Reflection;
using Vendor.Application.Interfaces;
using Vendor.Infrastructure.Services;
using ILogger = Vendor.Application.Interfaces.ILogger;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IDatabaseDriver), typeof(DatabaseDriver));
builder.Services.AddScoped(typeof(ILogger), typeof(Logger));
builder.Services.AddScoped(typeof(ISupplierService), typeof(SupplierService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger(c => c.RouteTemplate = string.Concat("vendor", "/swagger/{documentName}/swagger.json"));
    //app.UseSwaggerUI(c =>
    //{
    //    c.SwaggerEndpoint($"/vendor/swagger/v1/swagger.json", "Vendor vendor API V1");
    //    c.RoutePrefix = "vendor";
    //});

    app.UseSwagger();
    //app.UseSwaggerUI(options =>
    //{
    //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    //    options.RoutePrefix = string.Empty;
    //});
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "PlaceInfo Services"));
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
