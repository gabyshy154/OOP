using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MeetAgain.Client;
using MeetAgain.Client.Services;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// 🔧 Update this API base URL to match your backend port (5038)
builder.Services.AddScoped(sp => new HttpClient 
{ 
    BaseAddress = new Uri("http://localhost:5038/") // Point to Server
});

// ✅ Register app services
builder.Services.AddScoped<FriendService>();
builder.Services.AddScoped<FriendGroupService>();
builder.Services.AddScoped<MeetupService>();
builder.Services.AddScoped<AvailabilityService>();
builder.Services.AddScoped<NotificationService>(); // <-- Added

await builder.Build().RunAsync();
