using AutoMapper;
using HRMSApplication.Contracts;
using HRMSApplication.DapperORM;
using HRMSApplication.Identity;
using HRMSApplication.Repository;
using HRMSApplication.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddCors();

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ILoggerManager, LoggerManager>();
builder.Services.AddTransient<IEmployee, EmployeeRepository>();
builder.Services.AddSingleton<IAdminEmployee, AdminEmployeeRepository>();
builder.Services.AddSingleton<ICandidate, CandidateRepo>();
builder.Services.AddSingleton<IInductionRepo, InductionRepository>();
builder.Services.AddSingleton<IEmployOfferLetter, EmployeOfferLetterRepo>();
builder.Services.AddSingleton<IHolyday, HolydayRepository>();
builder.Services.AddSingleton<IJGL,JobGradeLRepo>();


builder.Services.AddTransient<IUser, UserRepository>();


builder.Services.AddTransient<EmployeeDapperContext>();
builder.Services.AddTransient<CandidateDapperContext>();
builder.Services.AddTransient<InductionDapperContext>();


//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//AddEntityFrameworkStores method to register the required EF Core implementation of Identity stores
builder.Services.AddIdentity<ApplicationUser, Microsoft.AspNetCore.Identity.IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();




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
