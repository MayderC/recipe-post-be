using System.Text;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Recipes.Adapter.Repositories;
using Recipes.Adapter.Services;
using Recipes.Application.Entities;
using Recipes.Application.Repositories;
using Recipes.Application.Services;
using Recipes.Database.Data;
using Recipes.WebAPI.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IRecipeTagService, RecipeTagService>();
builder.Services.AddScoped<ITagService, TagService>();


//Repositories
builder.Services.AddScoped<IUserRepository<User>, UserRepository>();
builder.Services.AddScoped<IRepository<User>, BaseRepository<User>>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRepository<RecipeTag>, BaseRepository<RecipeTag>>();
builder.Services.AddScoped<IRepository<Tag>, BaseRepository<Tag>>();

builder.Services.AddAutoMapper(typeof(Automapper));

builder.Services.AddDbContext<DataContext>(ops =>
{
    ops.UseSqlServer("Data source=localhost;Integrated Security=True;database=recipes-db");
});
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(cors =>
    {
        cors.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost").AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var keyValue = builder.Configuration.GetValue<string>("jwt");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "http://localhost",
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new
                SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyValue))
        };
    });





var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();