using Learn.D2.api.Extensions;
using Learn.D2.api.Features.EmailFeature;
using Learn.D2.api.Features.FirebaseFeature;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//All App Settings
builder.MapSettings();


//services
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<FirebaseService>();

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
