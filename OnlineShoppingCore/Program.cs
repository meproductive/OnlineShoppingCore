
using OnlineShoppingCore.Middlewares;
using OnlineShoppingCoreBLL.Abstract;
using OnlineShoppingCoreBLL.Concrete;
using OnlineShoppingCoreDAL.Abstract;
using OnlineShoppingCoreDAL.Concrete.EFCore;
using OnlineShoppingCoreDAL.Concrete.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Dependency Injection
builder.Services.AddScoped<IProductDAL, EFCoreProductDAL>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryDAL, EFCoreCategoryDAL>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

//MVC
builder.Services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Latest);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

SeedDatabase.Seed();

app.UseHttpsRedirection();
app.UseStaticFiles();
//app.CustomStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
    endpoints.MapControllerRoute(
        name: "products",
        pattern: "products/{category?}",
        defaults: new { controller = "Shop", action = "List" }
        );
    endpoints.MapControllerRoute(
        name: "adminProducts",
        pattern: "admin/products",
        defaults: new { controller = "Admin", action = "ProductList" }
        );
    endpoints.MapControllerRoute(
        name: "adminProducts",
        pattern: "admin/products/{id?}",
        defaults: new { controller = "Admin", action = "EditProduct" }
        );
    endpoints.MapControllerRoute(
        name: "adminCategories",
        pattern: "admin/categories",
        defaults: new { controller = "Admin", action = "CategoryList" }
        );
    endpoints.MapControllerRoute(
        name: "adminCategories",
        pattern: "admin/categories/{id?}",
        defaults: new { controller = "Admin", action = "EditCategory" }
        );

});

app.Run();

