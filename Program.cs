using ConfigureRedditService.Services;

var builder = WebApplication.CreateBuilder(args);

//DI setup
builder.Services.AddHttpClient<IOAuthClientService, OAuthClientService>(s => s.BaseAddress = new Uri("https://www.reddit.com/api/v1/"));
builder.Services.AddScoped<IFunnyDataService, FunnyDataService>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//setting up middleware pipeline
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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
