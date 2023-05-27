using SignInTechnologys.Configuration.LayerConfiguration;
using SignInTechnologys.Middlewares;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.ConfigureDataAccess(builder.Configuration);
builder.Services.AddService();
builder.Services.AddWeb(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseStatusCodePages(async context =>
{
	if (context.HttpContext.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
	{
		context.HttpContext.Response.Redirect("accounts/login");
	}
});

app.UseMiddleware<TokenRedirectMiddleware>();

//if (app.Services.GetService<IHttpContextAccessor>() != null)
//    HttpContextHelper.Accessor = app.Services.GetRequiredService<IHttpContextAccessor>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
