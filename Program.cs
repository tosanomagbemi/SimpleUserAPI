using Microsoft.EntityFrameworkCore;
using SimpleUserAPI.Data;

    var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<UserContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UsersConnection")));


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error"); // Enables detailed error pages
}


app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();

