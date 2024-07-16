using JourneyJoy.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var host = builder.Host;

// Add services to the container.
builder.Services.ConfigureMyServices(configuration, host);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// For Cors 
app.UseCors(options =>
{
    options
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin();
});

app.UseHttpsRedirection();

// For Authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
