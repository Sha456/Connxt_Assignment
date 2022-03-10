using Connxt.Core.Repository;
using Connxt.Core.Repository.Base;
using Connxt.Infrastructure.Data;
using Connxt.Infrastructure.Repository;
using Connxt.Infrastructure.Repository.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Connxt.Application.Handlers;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(c =>
    c.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"),
     sqlServerOptionsAction: sqlOptions =>
     {
         sqlOptions.EnableRetryOnFailure(10, TimeSpan.FromSeconds(30), null);
     }
     ), ServiceLifetime.Singleton
);

builder.Services.AddTransient<DatabaseContext>();
builder.Services.AddScoped(typeof(IReporsitory<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICreditCardValidationRepository), typeof(CreditCardValidationRepository));
// Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add MediatR
builder.Services.AddMediatR(typeof(PaymentHandler).GetTypeInfo().Assembly);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                         // builder.WithOrigins("https://localhost:4200");
                          builder.AllowAnyOrigin();
                          builder.AllowAnyHeader();
                          builder.AllowAnyMethod();
                        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();
app.MapControllers();

app.Run();