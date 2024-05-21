using BackEndCupons.Data;
using BackEndCupons.Services.Auth;
using BackEndCupons.Services.Coupons;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//registra los controladores en el contenedor de dependencias
builder.Services.AddControllers(); 

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Conexion base de datos
builder.Services.AddDbContext<CouponsContext>(
    option => option.UseMySql(
    builder.Configuration.GetConnectionString("MySql"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.2")));

//Cors
builder.Services.AddCors(options => 
    options.AddPolicy("AllowAnyOrigin",
    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()));

//registro de las interfaces al contenedor de dependencias
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<ICouponRepository, CouponRepository>();


//Jwt


//BCrypt


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//cors
app.UseCors("AllowAnyOrigin");

//Map
app.MapControllers(); 

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
