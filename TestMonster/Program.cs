var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<AnimalRepository>();

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

app.MapControllerRoute(
    name: "populate",
    pattern: "pop",
    defaults: new { controller = "Animals", action = "PopulatePage" });// need to use https://localhost:44337/pop

app.MapControllerRoute(
    name: "purge",
    pattern: "purge",
    defaults: new { controller = "Animals", action = "PurgePage" });// need to use https://localhost:44337/purge

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Animals}/{action=Index}/{id?}");

app.Run();

