using System.Text;
using BackEndCupons.Data;
using BackEndCupons.Models;
using BackEndCupons.Services.Auth;
using BackEndCupons.Services.Coupons;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
builder.Services.AddAuthentication(item =>
    {
        item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(item =>
    {
    item.RequireHttpsMetadata = true;
    item.SaveToken = true;
    item.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("9Y9+JKvPyNR0qmUGeCT1oHfCwK2E4EK9YiUCRLXL9D8=")),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew=TimeSpan.Zero
    };
});
var _jwtsettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(_jwtsettings);

//BCrypt


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

//cors
app.UseCors("AllowAnyOrigin");

//Map
app.MapControllers(); 

app.Run();

