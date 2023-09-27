using CarRental.Business.Classes;
using CarRental.Program;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using CarRental.Data;
using CarRental.Data.Classes;
using CarRental.Common.Classes;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton(sp => new BookingProcessor(new CollectionData()));
builder.Services.AddSingleton<Inputs>();
//builder.Services.AddSingleton(new BookingProcessor(new CollectionData()));

await builder.Build().RunAsync();
