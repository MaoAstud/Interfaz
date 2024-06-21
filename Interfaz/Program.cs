using Interfaz.Services;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession(); // Añadir soporte de sesión
builder.Services.AddDistributedMemoryCache(); // Añadir soporte de caché en memoria distribuida

// Configurar la autenticación
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

app.UseAuthentication(); // Añadir autenticación
app.UseAuthorization();

app.UseSession(); // Añadir soporte de sesión aquí

app.MapRazorPages();

app.Run();

// Configuración de HttpClient
builder.Services.AddHttpClient("BusDataClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:3750/data/bus");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

// Registrar ApiService
builder.Services.AddTransient<ApiService>();