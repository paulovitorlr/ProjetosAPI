using Microsoft.EntityFrameworkCore;
using ProjetosAPI.Data;
using ProjetosAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// 🔐 Connection String via Environment Variable
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")

    )
);

//  CORS 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();


app.UseHttpsRedirection();
app.UseCors("AllowFrontend");

app.MapProjetoEndpoints();

app.Run();
