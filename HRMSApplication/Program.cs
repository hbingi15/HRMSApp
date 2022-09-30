using AutoMapper;
using HRMSApplication.Contracts;
using HRMSApplication.Contracts.EmpAttendance;
using HRMSApplication.Contracts.JobGrdHld;
using HRMSApplication.DapperORM;
using HRMSApplication.Identity;
using HRMSApplication.Repository;
using HRMSApplication.Repository.AttendanceRepository;
using HRMSApplication.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NLog;
using NLog.Web;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();


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
builder.Services.AddSingleton<IJGL, JobGradeLRepo>();



builder.Services.AddTransient<IUser, UserRepository>();
builder.Services.AddTransient<IJobGrdHld, JobGrdHldRepository>();
builder.Services.AddTransient<IEmpAttendance, EmpAttendance>();
//builder.Services.AddTransient<IAuthent, TokenManager>();


builder.Services.AddTransient<EmployeeDapperContext>();
builder.Services.AddTransient<CandidateDapperContext>();
builder.Services.AddTransient<InductionDapperContext>();


//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var key = "This is my only Test Key";
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key))
    };
});



//DI
builder.Services.AddSingleton<IAuthent>(new HRMSApplication.Utilities.TokenManager(key));


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
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
