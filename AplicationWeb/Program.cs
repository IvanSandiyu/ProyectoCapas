using Microsoft.EntityFrameworkCore;
using Ad.DataContext;
using Ad.DataContext.Repositorio;
using DTOs.Usuarios;
using Ln.Service.Usuarios;
using NLog.Web;
using NLog;
using Ln.Service.Loggin;


var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("wenas");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();
    builder.Services.AddDbContext<BasePruebasContext>(opciones =>
    {
        opciones.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
    });


    //Inyeccion de dependencia

    builder.Services.AddScoped<IGenericRepositorio<Usuario>, UsuarioRepositorio>();
    builder.Services.AddScoped<IUsuarioService, UsuarioService>();
    builder.Services.AddScoped<ILogginService, LogginService>();//no se me esta haciendo la conec creo

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();


    var app = builder.Build();

    //// Actualización automática de la base de datos con migraciones al inicio de la aplicación
    //using (var scope = app.Services.CreateScope())
    //{
    //    var context = scope.ServiceProvider.GetRequiredService<BasePruebasContext>();
    //    context.Database.Migrate(); // Aplica las migraciones pendientes automáticamente
    //}

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
    }
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
catch(Exception ex)
{
    logger.Error(ex, "Ha ocurrido un error");
    
}
finally
{
    NLog.LogManager.Shutdown();
}

