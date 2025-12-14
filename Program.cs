using WebApplication_f.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Injection de depandence

builder.Services.AddSession(
    opt =>
    {
        opt.IdleTimeout = TimeSpan.FromSeconds(5);
        opt.Cookie.HttpOnly = true;
        opt.Cookie.Name = "SessionId";
    });
builder.Services.AddScoped<ISessionManagerService, SessionManagerService>();
var app = builder.Build();
//MiddleWare

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseSession(); //verifier la presence de cookie de session ID dans la requete
app.UseStaticFiles(); //2
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todos}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
