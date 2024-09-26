using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NyvaaSilksEcommerce.DataAccess;
using NyvaaSilksEcommerce.Manager;
using NyvaaSilksEcommerce.Repositories;
using NyvaaSilksEcommerce.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin",
        builder => builder
            .WithOrigins("http://localhost:4200") // Allow the Angular app origin
            .AllowAnyMethod()
            .AllowAnyHeader());
});
// Register the DatabaseHelper, Repository, and Services
builder.Services.AddScoped<DatabaseHelper>(sp => new DatabaseHelper(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAdminManager, AdminManager>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IProductCategoryManager, ProductCategoryManager>();
// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

// Add Authorization services
builder.Services.AddAuthorization();

// Register Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger(); // Enable middleware to serve Swagger UI
    app.UseSwaggerUI(); // Enable middleware to serve Swagger UI
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseCors("AllowMyOrigin"); // Apply the CORS policy

app.UseAuthorization();

app.MapControllers();

app.Run();
