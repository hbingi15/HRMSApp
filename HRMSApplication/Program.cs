using HRMSApplication.Contracts;
using HRMSApplication.DapperORM;
using HRMSApplication.Repository;
using HRMSApplication.Utilities;
using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddCors();

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ILoggerManager, LoggerManager>();
builder.Services.AddTransient<IEmployee, IEmployeeRepo>();
builder.Services.AddTransient<EmployeeDapperContext>();

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
