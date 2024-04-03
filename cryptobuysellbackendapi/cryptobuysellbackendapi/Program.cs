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


//CORS-----------------------------
    var specificOrgins = "BubbleParty";

    builder.Services.AddCors(corsoptions => corsoptions.AddPolicy(name: specificOrgins, policy => policy.WithOrigins("http://localhost:5173")));
    //CORS-----------------------------

    var app = builder.Build();

// Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        /*hsts was created to force your request to a website to use https instead of http otherwise somone could steal your packets on the first attempt of loggin in etc*/
        app.UseHsts();
        throw new Exception("Throwing an exception is different than catching an exception");
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseAuthorization();

    /*use routing is a setup function that routes incoming uri to the best matching controller*/
    app.UseRouting();

    /*allows our local host to acess itself from a different port*/
    app.UseCors(specificOrgins);

    /*this is just a cheasy way to create hard coded routes into our app at creation */
    app.MapGet("/", () => "Hello welcome to my cool homepage of the app i am building");

    /*lesson learned THIS HAS TO BE in the startup file otherwise the routes will not work!*/
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