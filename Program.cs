using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSingleton<IWeatherService, WeatherService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true, // Valida el emisor
            ValidateAudience = true, // Valida la audiencia
            ValidateLifetime = true, // Valida la expiración del token
            ValidateIssuerSigningKey = true, // Valida la firma del token
            ValidIssuer = "tu-emisor", // Emisor válido
            ValidAudience = "tu-audiencia", // Audiencia válida
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("tu-clave-secreta-muy-larga")) // Clave secreta para firmar el token
        };
    });

builder.Services.AddAuthorization();

// Need Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 
app.UseAuthentication();
app.UseAuthorization();
//

app.MapControllers();
app.UseHttpsRedirection();
app.Run();
