using DessigPatternsAsp.Configuration;
using Tools.Earn;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddControllersWithViews();
IConfigurationSection myconfig = configuration.GetSection("MyConfig") ;
builder.Services.Configure<MyConfig>(myconfig);


//Esto crea un objeto transendente para usarlo en el constructor
//Uso de inyeccion de dependencias evitando el new dentro del constructor
builder.Services.AddTransient((factory) =>
{
    //Esta linea realmente lo que hicimos fue agregar el valor en appsettings.json para que se vea mejor y poder reutilizarlo en la app
    decimal earnPercentage = myconfig.GetValue<decimal>("LocalPercentage");
    return new LocalEarnFactory(earnPercentage);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

