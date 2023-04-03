using ProductsMarket.Mvc.Configurations.LayerConfigurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDataAccess(builder.Configuration);
builder.Services.ConfigurWeb(builder.Configuration);
builder.Services.AddService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//app.UseStatusCodePages(async context =>
//{
//    if (context.HttpContext.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
//    {
//        context.HttpContext.Response.Redirect("login");
//    }
//});

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
