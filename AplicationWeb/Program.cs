using Microsoft.EntityFrameworkCore;
using Ad.DataContext;
using Ad.DataContext.Repositorio;
using Ad.DataContext.Repositorio.Persona;
using Ad.DataContext.Auditoria;
using Ad.DataContext.Categoria;
using Ad.DataContext.Cliente;
using Ad.DataContext.Deudas;
using Ad.DataContext.HistorialDeudas;
using Ad.DataContext.HistorialProductos;
using Ad.DataContext.Movimientos;
using Ad.DataContext.Stock;
using DTOs.Usuarios;
using DTOs.Persona;
using DTOs.Proveedor;
using DTOs.Auditoria;
using DTOs.Categoria;
using DTOs.Cliente;
using DTOs.Deudas;
using DTOs.HistorialDeudas;
using DTOs.HistorialProductos;
using DTOs.Movimientos;
using DTOs.Stock;
using NLog.Web;
using NLog;
using Ln.Service.Loggin;
using AplicationWeb.Controllers.Loggin;
using Ad.DataContext.LogginRepositorio;
using Ad.DataContext.ProveedorRepositorio;
using Ln.Service.Usuarios;
using Ln.Service.Persona;
using Ln.Service.Proveedor;
using Ln.Service.Auditoria;
using Ln.Service.Categoria;
using Ln.Service.Cliente;
using Ln.Service.Deudas;
using Ln.Service.HistorialDeudas;
using Ln.Service.HistorialProductos;
using Ln.Service.Movimientos;
using Ln.Service.Stock;
using Ln.Service.Producto;
using DTOs.Producto;
using DTOs.Paginacion;
using Ad.DataContext.ProductoRepositorio;




//var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
//logger.Debug("wenas");

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
    builder.Services.AddScoped<ILogginService, LogginService>();//no se me esta haciendo la conec creo -.Registra LogginService
    builder.Services.AddScoped<LogginRepositorio>(); // Registra LogginRepositorio
    builder.Services.AddScoped<IGenericRepositorio<PersonaDTO>, PersonaRepositorio>();
    builder.Services.AddScoped<IPersonaService, PersonaService>();
    builder.Services.AddScoped<IGenericRepositorio<ProveedorDTO>, ProveedorRepositorio>();
    builder.Services.AddScoped<IProveedorService, ProveedorService>();
    builder.Services.AddScoped<IGenericRepositorio<ProductoDTO>, ProductoRepositorio>();
    builder.Services.AddScoped<IProductoRepositorio<ProductoDTO>, ProductoRepositorio>();
    builder.Services.AddScoped<IProductoService, ProductoService>();
    builder.Services.AddScoped<IGenericRepositorio<AuditoriaDTO>, AuditoriaRepositorio>();
    builder.Services.AddScoped<IAuditoriaService, AuditoriaService>();
    builder.Services.AddScoped<IGenericRepositorio<CategoriaDTO>, CategoriaRepositorio>();
    builder.Services.AddScoped<ICategoriaService, CategoriaService>();
    builder.Services.AddScoped<IGenericRepositorio<ClienteDTO>, ClienteRepositorio>();
    builder.Services.AddScoped<IClienteService, ClienteService>();
    builder.Services.AddScoped<IGenericRepositorio<DeudasDTO>, DeudasRepositorio>();
    builder.Services.AddScoped<IDeudasService, DeudasService>();
    builder.Services.AddScoped<IGenericRepositorio<HistorialDeudasDTO>, HistorialDeudasRepositorio>();
    builder.Services.AddScoped<IHistorialDeudasService, HistorialDeudasService>();
    builder.Services.AddScoped<IGenericRepositorio<HistorialProductosDTO>, HistorialProductosRepositorio>();
    builder.Services.AddScoped<IHistorialProductosService, HistorialProductosServices>();
    builder.Services.AddScoped<IGenericRepositorio<MovimientosDTO>, MovimientosRepositorio>();
    builder.Services.AddScoped<IMovimientosServices, MovimientosService>();
    builder.Services.AddScoped<IGenericRepositorio<StockDTO>, StockRepositorio>();
    builder.Services.AddScoped<IStockService, StockService>();



    builder.Services.AddAuthentication("Cookies")
    .AddCookie(options =>
    {
        options.LoginPath = "/Loggin/Loggin"; // Ruta al formulario de login
    });
   




    //builder.Logging.ClearProviders();
    //builder.Host.UseNLog();


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
        pattern: "{controller=Loggin}/{action=Loggin}/{id?}");

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Index}/{action=Home}/{id?}");

    app.MapControllerRoute(
       name: "default",
       pattern: "{controller=Producto}/{action=CrearProducto}/{id?}");



    app.Run();
}
catch(Exception ex)
{
    Console.WriteLine($"Error durante la inicialización: {ex.Message}");
    Console.WriteLine(ex.StackTrace);
    //logger.Error(ex, "Ha ocurrido un error");

}
finally
{
    NLog.LogManager.Shutdown();
}

