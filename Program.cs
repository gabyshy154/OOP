using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MeetAgain;
using MeetAgain.Services;

try
{
    var builder = WebAssemblyHostBuilder.CreateDefault(args);

    // Root components
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");

    // HttpClient for API calls (optional, can be removed if unused)
    builder.Services.AddScoped(sp => new HttpClient 
    { 
        BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) 
    });

    // Register services (Scoped is safer for Blazor WASM)
    builder.Services.AddScoped<FriendService>();
    builder.Services.AddScoped<MeetupService>();
    builder.Services.AddScoped<NotificationService>();

    var host = builder.Build();

    await host.RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"Startup Exception: {ex.Message}");
}
