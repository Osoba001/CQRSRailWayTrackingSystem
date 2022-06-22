using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RailWayAppLibrary.Utility;
using RailWayInfrastructureLibrary.Authenticate;
using RailWayInfrastructureLibrary.Data;
using RailWayInfrastructureLibrary.Dependency;
using RailWayInfrastructureLibrary.Utility;
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
builder.Services.AddSingleton<IAuthenticationManager>(new JWTAuthenticationManager(key));

builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    opt.AddPolicy("AdminAndAccountant", policy => policy.RequireAssertion(context =>
                  context.User.IsInRole("Admin") || context.User.IsInRole("Accountant")));
    opt.AddPolicy("AdminAndTrainEngineerOnly", policy => policy.RequireAssertion(context =>
                  context.User.IsInRole("TrainEngineer") || context.User.IsInRole("Admin")));
    opt.AddPolicy("AdminAndStationAdmin", policy => policy.RequireAssertion(context =>
                  context.User.IsInRole("TrainEngineer") || context.User.IsInRole("Admin")));
    opt.AddPolicy("AdultOnly", policy => policy.RequireClaim("Email")
                .Requirements.Add(new AdultRequirement(18)));
    opt.AddPolicy("AdminTrainEngineerAndStationAdminOnly", policy => policy.RequireAssertion(context =>
                  context.User.IsInRole("TrainEngineer") || context.User.IsInRole("Admin")
                  && context.User.IsInRole("Passenger")));
    opt.AddPolicy("AdminAndPassenger", policy => policy.RequireAssertion(context =>
                  context.User.IsInRole("Admin") || context.User.IsInRole("Passenger")));
});
 
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
