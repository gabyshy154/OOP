using Microsoft.EntityFrameworkCore;
using MeetAgain.Server.Data;

var builder = WebApplication.CreateBuilder(args);

// --------------------
// Add services
// --------------------
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Database connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(connectionString))
{
    // Default fallback to SQLite if config is missing
    connectionString = "Data Source=meetagain.db";
}

if (connectionString.Contains("Data Source="))
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite(connectionString));
}
else
{
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));
}

// --------------------
// CORS policy for Blazor client
// --------------------
var AllowClient = "_allowClient";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowClient,
        policy =>
        {
            policy.WithOrigins("http://localhost:5000") // Blazor client URL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// --------------------
// Swagger
// --------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --------------------
// Configure middleware
// --------------------
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// ❌ No HTTPS redirect on localhost without SSL
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

// CORS must come BEFORE endpoints
app.UseCors(AllowClient);

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

// --------------------
// Apply migrations at startup
// --------------------
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}

app.Run();
