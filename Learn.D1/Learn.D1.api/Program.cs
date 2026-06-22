using Learn.D1.api.Features.Database;
using Learn.D1.api.Features.JwtFeature;
using Learn.D1.api.Features.TestFeature;
using Learn.D1.api.Models.DbModles;
using Learn.D1.api.Models.JwtModels;
using Learn.D1.api.Models.TestModels;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();



/*********************** Add AppInfoSetting ***************************************/
builder.Configuration.AddJsonFile("appInfo.json");
var builderAppInfoSettings = new ConfigurationBuilder();
builderAppInfoSettings
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appInfo.json",optional:true,reloadOnChange:true);
IConfiguration appInfoConfi = builderAppInfoSettings.Build();

/*********************** Add AppConnectionSettings ***************************************/
builder.Configuration.AddJsonFile("appConnection.json");
var builderAppConnection = new ConfigurationBuilder();
builderAppConnection.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appConnection.json",optional:true,reloadOnChange:true);
IConfiguration appConnectionConfi = builderAppConnection.Build();

/*********************** Options With Validation ***************************************/
builder.Services.AddOptions();

builder.Services.AddOptions<JwtSettings>()
    .Bind(builder.Configuration.GetSection("JwtSettings"))
    .ValidateDataAnnotations()
    .ValidateOnStart();
builder.Services.Configure<AppInfo>(appInfoConfi.GetSection("AppInfo"));
builder.Services.Configure<AppConnection>(appConnectionConfi.GetSection("AppConnection"));


//builder.Environment.EnvironmentName
//var env = builder.Environment;


//services
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<AppInfoService>();
builder.Services.AddScoped<AppConnectionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
