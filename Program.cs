// CreateBuilder does some basic setup of the ASP.NET Core platform
// ensures startup looks at the appsettings.json file and loads the settings from that file as well as Kestrel

using Microsoft.EntityFrameworkCore;
using MithrasPieShop.Models;

var builder = WebApplication.CreateBuilder(args);

// ADD SERVICES TO CONTAINER //

// bring in our own services
//builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>(); //using Mock Models
//builder.Services.AddScoped<IPieRepository, MockPieRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MithrasPieShopDbContext>(options =>
{
    options.UseMySql(builder.Configuration["ConnectionStrings:MithrasPieShopDBContextConnection"],
        new MySqlServerVersion(new Version()));
});
// If you dont put the above information here, then you put it in the DBContext and use the following here:
//builder.Services.AddDbContext<MithrasPieShopDbContext>();

// final step of initialization. App is of type WebApplication used for setting up middleware
var app = builder.Build();

// MIDDLEWARE REQUEST PIPELINE STARTS //

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

// set some defaults used typically in MVC to route to the pages that we are going to have
/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");*/
// above is same as saying app.MapDefaultControllerRoute();
app.MapDefaultControllerRoute();

// ADD THE SEED DATA TO THE DATABASE // - only runs once when database is empty
DbInitializer.Seed(app);

// RUN THE APP //

app.Run();