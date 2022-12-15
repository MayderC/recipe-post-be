using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
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
builder.Services.AddScoped<IRepository<Recipe>, BaseRepository<Recipe>>();
builder.Services.AddScoped<IRepository<RecipeTag>, BaseRepository<RecipeTag>>();
builder.Services.AddScoped<IRepository<Tag>, BaseRepository<Tag>>();

builder.Services.AddAutoMapper(typeof(Automapper));

builder.Services.AddDbContext<DataContext>(ops =>
{
    ops.UseSqlServer("Data source=localhost;Integrated Security=True;database=recipes-db");
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate();

var keyValue = builder.Configuration.GetValue<string>("jwt");
builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

var app = builder.Build();

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