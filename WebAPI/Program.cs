using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Service.Extensions;
using Service.Initialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<UniqueFashionDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr"), sqlOptions =>
    {
        sqlOptions.CommandTimeout(180); // Increase timeout to 180 seconds (or adjust as necessary)
    });
});
builder.Services.AddExtensions();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddJwtSettings(builder.Configuration);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SellerPolicy", policy => policy.RequireRole("Seller"));
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // This will show detailed error pages
}
using (var scope = app.Services.CreateScope())
{
    var roleInitializer = scope.ServiceProvider.GetRequiredService<RoleInitializer>();
    await roleInitializer.InitializeAsync();
}
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
