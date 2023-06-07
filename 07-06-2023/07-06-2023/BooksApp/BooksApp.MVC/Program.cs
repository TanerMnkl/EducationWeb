using AspNetCoreHero.ToastNotification;
using BooksApp.Business.Abstract;
using BooksApp.Business.Concrete;
using BooksApp.Data.Abstract;
using BooksApp.Data.Concrete.EfCore.Contexts;
using BooksApp.Data.Concrete.EfCore.Repositories;
using BooksApp.Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BooksAppContext>(options=>options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<BooksAppContext>()
    .AddDefaultTokenProviders();/*mail i�in kullanaca��z sadece.*/

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true; //�ifre i�inde say�sal deger olmal� m�?
    options.Password.RequireLowercase = true;//�ifre i�inde k���k harf olmmal� m�?

    options.Password.RequireUppercase = true;//b�y�k harf olmal� m�
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;//�zel bir karakter konulmas� gerekiyor mu


    options.Lockout.MaxFailedAccessAttempts = 3; //ka� kez hata �ans�m�z var
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);  //�st �ste izin verilen kez hatal� giri� yapmaya �al��al�an hesap hangi s�reyle kitlenicek.

    options.User.RequireUniqueEmail = true;  //sistemde daha �nce kay�tl� olmayan bir mail aderesi doldurmak zorunda olsun.

    options.SignIn.RequireConfirmedEmail = true; ///kay�t olunurken email onay� istenir.

    options.SignIn.RequireConfirmedPhoneNumber = false;//telefon onnay�

    builder.Services.ConfigureApplicationCookie(options =>
    {
        options.LoginPath = "/account/login";//E�er kullan�c� eri�ebilmesi i�in login olmak zorunda oldu�u bir istekte bulunursa, y�nlendirilecek path.
        options.LogoutPath = "/account/logout";//Logout oldu�unda y�nlendirilecek action
        options.AccessDeniedPath = "/account/accessdenied";//Kullan�c� yetkisi olmayan bir endpointe istekte bulunursa y�nlendirilecek path
        options.ExpireTimeSpan = TimeSpan.FromMinutes(3);//Cookiemizin ya�am s�resi ne kadar olacak?
        options.SlidingExpiration = true;
        options.Cookie = new CookieBuilder
        {
            HttpOnly = true,
            SameSite = SameSiteMode.Strict,
            Name = "BooksApp.Security.Cookie"
        };
    });


});

builder.Services.AddScoped<IAuthorService, AuthorManager>();
builder.Services.AddScoped<IBookService, BookManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IPublisherService, PublisherManager>();

builder.Services.AddScoped<IAuthorRepository, EfCoreAuthorRepository>();
builder.Services.AddScoped<IBookRepository, EfCoreBookRepository>();
builder.Services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
builder.Services.AddScoped<IPublisherRepository, EfCorePublisherRepository>();

builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 5;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;
});
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles(); /*www.root klas�r�ne var eden */
app.UseAuthentication();/*ki�iye kimligini soran bu. yani �nce gelenin kim oldugunu sorar�z sonra yetkisi var m� diye bakar�z ondan dolay� authorizationun �st�ne yazmam�z gerekiyor.kimlik kontrol� yetki kontrol�nden �nce olmas� gerekiyor.*/

app.UseRouting();

app.UseAuthorization(); /*yetkiye bakan bu yetkiyi kontrol edip i�eri alm�yor sadece yetkiyi inceliyor�*/




app.MapControllerRoute(
    name: "bookdetails",
    pattern: "kitapdetay/{url}",
    defaults: new { controller = "BooksShop", action = "BookDetails" }
    );

app.MapControllerRoute(
    name: "bookspublisher",
    pattern: "kitaplar/{publisherurl?}",
    defaults: new { controller = "BooksShop", action = "BookList" }
    );

app.MapControllerRoute(
    name: "booksauthor",
    pattern: "kitaplar/{authorurl?}",
    defaults: new { controller = "BooksShop", action = "BookList" }
    );

app.MapControllerRoute(
    name: "bookscategory",
    pattern: "kitaplar/{categoryurl?}",
    defaults: new { controller = "BooksShop", action = "BookList" }
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
