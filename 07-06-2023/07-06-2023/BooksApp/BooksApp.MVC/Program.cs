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
    .AddDefaultTokenProviders();/*mail için kullanacaðýz sadece.*/

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true; //þifre içinde sayýsal deger olmalý mý?
    options.Password.RequireLowercase = true;//þifre içinde küçük harf olmmalý mý?

    options.Password.RequireUppercase = true;//büyük harf olmalý mý
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;//özel bir karakter konulmasý gerekiyor mu


    options.Lockout.MaxFailedAccessAttempts = 3; //kaç kez hata þansýmýz var
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);  //üst üste izin verilen kez hatalý giriþ yapmaya çalýþalýan hesap hangi süreyle kitlenicek.

    options.User.RequireUniqueEmail = true;  //sistemde daha önce kayýtlý olmayan bir mail aderesi doldurmak zorunda olsun.

    options.SignIn.RequireConfirmedEmail = true; ///kayýt olunurken email onayý istenir.

    options.SignIn.RequireConfirmedPhoneNumber = false;//telefon onnayý

    builder.Services.ConfigureApplicationCookie(options =>
    {
        options.LoginPath = "/account/login";//Eðer kullanýcý eriþebilmesi için login olmak zorunda olduðu bir istekte bulunursa, yönlendirilecek path.
        options.LogoutPath = "/account/logout";//Logout olduðunda yönlendirilecek action
        options.AccessDeniedPath = "/account/accessdenied";//Kullanýcý yetkisi olmayan bir endpointe istekte bulunursa yönlendirilecek path
        options.ExpireTimeSpan = TimeSpan.FromMinutes(3);//Cookiemizin yaþam süresi ne kadar olacak?
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

app.UseStaticFiles(); /*www.root klasörüne var eden */
app.UseAuthentication();/*kiþiye kimligini soran bu. yani önce gelenin kim oldugunu sorarýz sonra yetkisi var mý diye bakarýz ondan dolayý authorizationun üstüne yazmamýz gerekiyor.kimlik kontrolü yetki kontrolünden önce olmasý gerekiyor.*/

app.UseRouting();

app.UseAuthorization(); /*yetkiye bakan bu yetkiyi kontrol edip içeri almýyor sadece yetkiyi inceliyorç*/




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
