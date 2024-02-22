using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
/*i added this since i dont think we need the views here*/
builder.Services.AddControllers();

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
app.UseAuthorization();


/*FOR RIGHT NOW I AM GOING TO IGNORE ATTRIBUTE BASED ROUTING AND JUST DO CONVENTION BASED*/

app.UseRouting();
app.UseEndpoints(endpoionts =>
{
app.MapControllerRoute(
    name: "fucker",/*You can name the routes whatever you want but normally just call it default*/
/*This is setting the defaults to our controller class*/
    /*1st part is the controller name*/
    /*2nd part is the method name it defaults too if not passed in the url*/
    /*3rd part is the aurgument the user provides if there are paramaters*/
    pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();