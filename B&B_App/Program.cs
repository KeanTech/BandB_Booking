using B_B_App;
using B_B_App.Core.Managers;
using B_B_App.Services;
using B_B_ClassLibrary.BusinessModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
LoginManager.Login(new B_B_ClassLibrary.BusinessModels.User() { FirstName = "Kenneth" });

Uri uri = new Uri("http://192.168.1.101:5188");

builder.Services.AddHttpClient<IRoomService<Room>, RoomService>(client =>
{
    client.BaseAddress = uri;
});

builder.Services.AddHttpClient<IUserService<User>, UserService>(client =>
{
    client.BaseAddress = uri;
});

builder.Services.AddHttpClient<ILandlordService<Landlord>, LandlordService>(client =>
{
    client.BaseAddress = uri;
});

builder.Services.AddHttpClient<IPictureService, PictureService>(client =>
{
    client.BaseAddress = uri;
});


builder.Services.AddSingleton<LoginManager>();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
await builder.Build().RunAsync();
