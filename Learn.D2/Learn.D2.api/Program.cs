using Learn.D2.api.Extensions;
using Learn.D2.api.Features.EmailFeature;
using Learn.D2.api.Features.FirebaseFeature;
using Learn.D2.api.Features.GameFeature;
using Learn.D2.api.Features.UserFeature;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.MapSettings();
builder.MapDatabase();


//services
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<FirebaseService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<GameService>();


//APP
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
