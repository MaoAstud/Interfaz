var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession(); // A�adir soporte de sesi�n
builder.Services.AddDistributedMemoryCache(); // A�adir soporte de cach� en memoria distribuida

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

app.UseAuthorization();

app.UseSession(); // A�adir soporte de sesi�n aqu�

app.MapRazorPages();

app.Run();
