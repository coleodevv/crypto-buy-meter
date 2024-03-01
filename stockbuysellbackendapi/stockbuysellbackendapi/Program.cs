using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
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


app.UseRouting();
/*as far as i am concerned this just sets a defaul route as middleware when the app instance gets initialized*/
app.MapControllerRoute(
   name: "Home" ,
   pattern: "{controller=Home}/{action=HomePage}/{id?}"
    );

app.Run();