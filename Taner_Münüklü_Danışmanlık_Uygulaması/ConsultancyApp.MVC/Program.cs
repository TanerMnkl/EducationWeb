
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Notyf.Models;
using ConsultancyApp.Business.Abstract;
using ConsultancyApp.Business.Concrete;
using ConsultancyApp.Data.Abstract;
using ConsultancyApp.Data.Concrete.EfCore.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ILessonService, LessonManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IAgencyService, AgencyManager>();


builder.Services.AddScoped<ILessonRepository,EfCoreLessonRepository>();
builder.Services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
builder.Services.AddScoped<IAgenciesRepository, EfCoreAgencyRepository>();


builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 5;
    config.IsDismissable = true;
    config.Position = NotyfPosition.BottomRight;
});

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

//app.MapControllerRoute(
//    name: "lessonagency",
//    pattern: "egitimler/{agencyurl?}",
//    defaults: new { controller = "LessonShop", action = "LessonList" }
//    );
app.MapControllerRoute(
    name: "lessoncategory",
    pattern: "egitimler/{categoryurl?}",
    defaults: new { controller = "LessonShop", action = "LessonList" }
    );
app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "admin/{controller=Home}/{action=Index}/{id?}"
    );


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
