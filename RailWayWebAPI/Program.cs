using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RailWayAppLibrary.Utility;
using RailWayInfrastructureLibrary.Data;
using RailWayInfrastructureLibrary.Dependency;
using RailWayWebAPI.Controllers;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RailWayDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.Dependency();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
var key  = builder.Configuration.GetSection("AppSetting:Token").Value;

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
   {
       x.RequireHttpsMetadata = false;
       x.SaveToken = true;
       x.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuerSigningKey = true,
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
           ValidateIssuer = false,
       };
   });
builder.Services.AddSingleton<JWTAuthenticationManager>(new JWTAuthenticationManager(key));
 
var AllowSpecificOrigin = "_allowspecificOrigin";
builder.Services.AddCors(option =>
{
    option.AddPolicy(name: AllowSpecificOrigin, policy =>
     {
         policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
     });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(AllowSpecificOrigin);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
