using Interfaz.Services;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession(); // A�adir soporte de sesi�n
builder.Services.AddDistributedMemoryCache(); // A�adir soporte de cach� en memoria distribuida

// Configurar la autenticaci�n
builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", config =>
    {
        config.Cookie.Name = "UserLoginCookie";
        config.LoginPath = "/Login";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // A�adir autenticaci�n
app.UseAuthorization();

app.UseSession(); // A�adir soporte de sesi�n aqu�

app.MapRazorPages();

app.Run();

// Configuraci�n de HttpClient
builder.Services.AddHttpClient("BusDataClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:3750/data/bus");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

// Registrar ApiService
builder.Services.AddTransient<ApiService>();