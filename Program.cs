using Challenge03.Data;
using Challenge03.Dtos;
using Challenge03.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("ProjectDb");

builder.Services.AddSqlite<ProjectContext>(connString);

// Register HttpClientFactory
builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// List<CategoryDto> categories = [
//     new (1, "Kids and Family"),
//     new (2, "Eco-Friendly Living")
// ];

//app.MapGet("/categories",() => categories);



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapCategoryEndpoint();
app.MigrateDb();

app.MapRazorPages();

app.Run();
