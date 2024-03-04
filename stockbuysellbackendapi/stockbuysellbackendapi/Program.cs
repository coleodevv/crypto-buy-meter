using System.Diagnostics;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

     Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(theme: ConsoleTheme.None)
    .CreateLogger();


     string turtlesInTime = "LETS KICK SHELL COWABUNGA!";

try
{
    Log.Information("The application is started now {@turtlesInTime}", turtlesInTime);
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog(); /*THIS LINE IS IMPORTANT FOR SERILOG TO WORK!*/

// Add services to the container.
    builder.Services.AddControllers();


    var app = builder.Build();

// Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
        throw new Exception("The app host enviorment name is not DEVELOPMENT");
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseAuthorization();

/*Every app has a route builder and this just populates the defualt route when visiting the default base uri*/
    app.UseRouting();
/*as far as i am concerned this just sets a defaul route as middleware when the app instance gets initialized*/
    app.MapControllerRoute(
        name: "Home",
        pattern: "{controller=Home}/{action=HomePage}/{id?}"
    );

    app.Run();
}

catch (Exception e)
{
    Log.Fatal(e, "Application has terminated unexpectedly");
    Log.Fatal(e, "This is fucking cool we can try catch to run the entire app and if it fails to run we throw our own custom exception");
}
finally
{
    Log.CloseAndFlush();
}