using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StockManagementSystem.API;
using StockManagementSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.MigrationsAssembly("StockManagementSystem.Infrastructure")));
builder.Services.AddControllers();
builder.Services.AddTransient<IProductsManager, ProductsManager>();
builder.Services.AddTransient<IUserManager, UserManager>();

// Add services to the container.
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

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
