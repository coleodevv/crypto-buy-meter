var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseEndpoints(endpoionts =>
{
app.MapControllerRoute(
    name: "default",
/*This is setting the defaults to our controller class*/
    /*1st part is the controller name*/
    /*2nd part is the method name it defaults too if not passed in the url*/
    /*3rd part is the aurgument the user provides if there are paramaters*/
    pattern: "{controller=Home}/{action=}/{id?}");
});


app.Run();