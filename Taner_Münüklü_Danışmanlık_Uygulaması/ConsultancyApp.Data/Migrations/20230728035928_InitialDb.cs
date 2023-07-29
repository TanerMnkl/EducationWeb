using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConsultancyApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    About = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    FoundationYear = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    About = table.Column<string>(type: "TEXT", nullable: false),
                    AgenciesId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    HowManyOfExperince = table.Column<int>(type: "INTEGER", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    About = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    About = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    AgenciesId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Kontenjan = table.Column<int>(type: "INTEGER", nullable: false),
                    PeriodOfStudy = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Agencies_AgenciesId",
                        column: x => x.AgenciesId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "AgenciesCategory",
                columns: table => new
                {
                    AgenciesId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgenciesCategory", x => new { x.AgenciesId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_AgenciesCategory_Agencies_AgenciesId",
                        column: x => x.AgenciesId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AgenciesCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoriesLessons",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    AgenciesId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesLessons", x => new { x.LessonId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CategoriesLessons_Agencies_AgenciesId",
                        column: x => x.AgenciesId,
                        principalTable: "Agencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoriesLessons_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriesLessons_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Agencies",
                columns: new[] { "Id", "About", "CategoryId", "City", "CreatedDate", "FoundationYear", "ImageUrl", "IsActive", "IsDeleted", "LessonId", "ModifiedDate", "Name", "Price", "Url" },
                values: new object[,]
                {
                    { 1, "bu bir silinmiş ajansların bulunacağı kısımdır.", 0, "İstanbul", new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7803), 1, "genel-egitim-kurumu", true, false, 1, new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7817), "Genel", 0.0, "genel-egitim-kurumu" },
                    { 2, "bu bir backend egitimi veren  firmadır", 0, "İstanbul", new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7826), 2000, "ferisoft-egitim-kurumu", true, false, 19, new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7826), "Ferisoft", 150.0, "ferisoft-egitim-kurumu" },
                    { 3, "bu bir veri tabanı firmasıdır", 0, "İstanbul", new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7828), 2000, "evkal-egitim-kurumu", true, false, 19, new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7828), "Evkal", 150.0, "evkal-egitim-kurumu" },
                    { 4, "bu bir Android programlama firmasıdır", 0, "İstanbul", new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7831), 2000, "appricot-egitim-kurumu", true, false, 19, new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7832), "Appricot", 150.0, "appricot-egitim-kurumu" },
                    { 5, "bu bir IOS ve bulut bilişim egitim firmasıdır", 0, "İstanbul", new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7835), 2000, "appwox-egitim-kurumu", true, false, 19, new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7835), "Appwox", 150.0, "appwox-egitim-kurumu" },
                    { 6, "bu bir Cybersecurity firmasıdır", 0, "İstanbul", new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7837), 2000, "taze-egitim-kurumu", true, false, 19, new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7837), "Taze", 150.0, "taze-egitim-kurumu" },
                    { 7, "bu bir Tasarım firmasıdır", 0, "İstanbul", new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7865), 2000, "house-of-apps-egitim-kurumu", true, false, 19, new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7865), "House Of Apps", 150.0, "house-of-apps-egitim-kurumu" },
                    { 8, "bu bir web application egitim firmasıdır", 0, "İstanbul", new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7867), 2000, "westerops-egitim-kurumu", true, false, 19, new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7868), "Westerops", 150.0, "westerops-egitim-kurumu" },
                    { 9, "bu bir oyun programlama firmasıdır", 0, "İstanbul", new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7873), 2002, "vayes-egitim-kurumu", true, false, 19, new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7873), "Vayes", 100.0, "vayes-egitim-kurumu" },
                    { 10, "bu bir Cybersecurity egitim firmasıdır", 0, "İstanbul", new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7875), 1975, "cremicro-egitim-kurumu", true, false, 19, new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7875), "Cremıcro", 355.0, "cremicro-egitim-kurumu" },
                    { 11, "bu bir Tasarım ve Marka oluşturma firmasıdır", 0, "İstanbul", new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7877), 2005, "galta-media-egitim-kurumu", true, false, 19, new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7877), "galta media", 150.0, "galta-media-egitim-kurumu" },
                    { 12, "bu bir frontend firmasıdır", 0, "İstanbul", new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7823), 2000, "mellon-egitim-kurumu", true, false, 19, new DateTime(2023, 7, 28, 6, 59, 28, 159, DateTimeKind.Local).AddTicks(7824), "Mellon", 150.0, "mellon-egitim-kurumu" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "About", "AgenciesId", "CreatedDate", "IsActive", "IsDeleted", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Burada  kategorisi olmayan eğitimler olacak.", 0, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(122), true, false, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(125), "Genel", "genel-ile-ilgili-egitim" },
                    { 2, "Burada backend  egitimleri veriliyor", 0, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(132), true, false, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(132), "Backend Egitimi", "backend-ile-ilgili-egitim" },
                    { 3, "Burada veritabanı Egitimleri veriliyor", 0, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(133), true, false, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(134), "Veritabanı Egitimi", "veri-tabanı-ile-ilgili-egitim" },
                    { 4, "Burada veritabanlı  egitimleri veriliyor.", 0, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(135), true, false, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(135), "Bulut bilişimler ve ios", "bulut-bilisimler-ve-ios-ile-egitim" },
                    { 5, "Burada Android programların egitimi verilecek", 0, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(137), true, false, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(137), "Web App", "web-app-ile-egitim" },
                    { 6, "Burada Veri analizi ve ios programlama egitimleri veriliyor", 0, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(138), true, false, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(139), "Oyun ve Android Programlama", "oyun-ve-android-programlama-ile-egitim" },
                    { 7, "Seo optimazsonu ve reklam tekniklerini ögreten ve logo oluşturmayı ögreten bir firma", 0, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(140), true, false, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(140), "Reklam ve Pazarlama", "reklam-pazarlama-ile-egitim" },
                    { 8, "Burada dotnet egitimleri verilecek", 0, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(142), true, false, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(142), ".Net Egitimi", "dotnet--ile-egitim" },
                    { 9, "Burada güvenlik egitimleri verilecek", 0, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(143), true, false, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(144), "CyberSecurity", "cyber-security-ile-egitim" },
                    { 21, "Burada frontend egitimleri veriliyor", 0, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(129), true, false, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(130), "frontend", "frontend-ile-ilgili-egitim" }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "About", "AgenciesId", "CreatedDate", "ImageUrl", "IsActive", "IsDeleted", "Kontenjan", "ModifiedDate", "Name", "PeriodOfStudy", "Price", "Url" },
                values: new object[,]
                {
                    { 1, "Full stack developer olarak çalışan uzmanlar, yazılımların back-end (arka katman) ve front-end(ön katman) olarak nitelendirilen bölümlerinde rol almaktadırlar. Aynı zamanda veritabanı programlama alanlarında yetkinlikleri olup, geliştirilmekte olan projenin yazılımla ilgili bütün aşamalarında görev almaktadırlar. Full Stack Development, HTML, CSS, JavaScript, ReactJS, Node.JS gibi birçok dil barındırmaktadır. Doğası gereği geniş ilgi alanına sahip bir disiplindir. Back-End’den Front-End’e ve veritabanlarına kadar uzanan bu yetkinlik Türkiye’de en çok aranan yazılım programlama dallarından biridir.", 1, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7721), "full-stack-web-application.jpg", true, false, 15, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7725), "Full Stack Web Application", 165, 70.000m, "full-stack-web-application.jpg" },
                    { 2, "Bilişim sektöründe yer almayı hedefleyen öğrenci ve mezunlar, bu dilde kendisini geliştirip uzmanlaşmak isteyen ve kariyerini bilişim sektöründe ilerletmek isteyenlerin tercih edebileceği bu eğitimde hızlı ve dinamik web uygulamaları geliştirmek, Python programlama dilinin artılarından yararlanmak için alabileceğiniz bu eğitim ile sıfırdan ileri seviyeye web geliştirici olma imkanını yakalayın.\r\n\r\n\r\n\r\nSektör tecrübesi yüksek uzman eğiticiler tarafından yapılacak online eğitimde katılımcılar alacakları teorik bilginin yanında edinecekleri uygulama deneyimi ile özelleştirilmiş ve hedefe yönelik bir eğitim alırlar.\r\n\r\n", 1, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7734), "python-ile-web-gelistirme.jpg", true, false, 15, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7734), "Python ile Web Geliştirme", 85, 30.000m, "python-ile-web-gelistirme" },
                    { 3, "Bilişim sektöründe yer almayı hedefleyen öğrenci ve mezunlar, bu dilde kendisini geliştirip uzmanlaşmak isteyen ve kariyerini bilişim sektöründe ilerletmek isteyenlerin tercih edebileceği bu eğitimde, katılımcıların dünyanın en popüler ve güçlü programlama dillerinden Java'yı tanımaları ve uygulama geliştirecek seviyeye gelmeleri amaçlanmaktadır. Java Eğitiminde, veritabanı yönetimi ve programlanması MySql ilişkisel veritabanı yönetim sistemi ile gerçekleştirilir.\r\n\r\n \r\n\r\nBu eğitimi alan katılımcılar, ayrıca Java programlama dili ile beraber, kodlaması yapılmış bir uygulamada MySql veritabanına JDBC gibi erişim teknikleriyle nasıl bağlanılacağını, veritabanı üzerinde nasıl işlem gerçekleştirilebileceğini çeşitli uygulamalarla öğrenirler.", 1, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7737), "java-ile-egitim.png", true, false, 15, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7737), "Java Eğitimi (SE)", 165, 70.000m, "java-ile-egitim" },
                    { 4, "Bilişim sektöründe yer almayı hedefleyen öğrenci ve mezunlar, bu dilde kendisini geliştirip uzmanlaşmak isteyen ve kariyerini bilişim sektöründe ilerletmek isteyenlerin tercih edebileceği bu eğitimde hızlı ve dinamik web uygulamaları geliştirmek, Python programlama dilinin artılarından yararlanmak için alabileceğiniz bu eğitim ile sıfırdan ileri seviyeye oyun geliştirici olma imkanını yakalayın.\r\n\r\n\r\n\r\nSektör tecrübesi yüksek uzman eğiticiler tarafından yapılacak online eğitimde katılımcılar alacakları teorik bilginin yanında edinecekleri uygulama deneyimi ile özelleştirilmiş ve hedefe yönelik bir eğitim alırlar.\r\n\r\n", 1, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7739), "oyun-programlama-ile-egitim.png", true, false, 15, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7739), "Oyun Programlama", 600, 70.000m, "oyun-programlama" },
                    { 5, "Bilişim sektöründe yer almayı hedefleyen öğrenci ve mezunlar, bu dilde kendisini geliştirip uzmanlaşmak isteyen ve kariyerini bilişim sektöründe ilerletmek isteyenlerin tercih edebileceği bu eğitimde katılımcıların, PHP ile web yazılıma giriş yapmaları sağlanır ayrıca nesne yönelimli programlamayı (OOP) etkin bir biçimde kullanarak katmanlı yapıdaki proje mimarisi ile birlikte servis alt yapısının da kullanıldığı modüler web projeleri geliştirilmeleri sağlanır.\r\n\r\n \r\n\r\nServer side yazılım dillerinden olan PHP öğrenmek günümüzde popüler olan ve nitelikli uzman eleman açığı bulunan Wordpress, Laravel gibi frameworkler için ciddi bir temel oluşturacaktır.\r\n\r\n \r\n\r\nBir web sitesinin sıfırdan nasıl oluşturulduğunu, MySQL veritabanı bağlantısının nasıl kurulduğunu, veritabanı sorgulamalarını, etkili ve işlevsel bir websitesi hazırlamanın inceliklerini bu eğitimde öğrenebilirsiniz.", 1, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7741), "php-ile-egitim.png", true, false, 15, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7742), "Php Eğitimi", 72, 70.000m, "php-ile-egitim" },
                    { 6, "Bilişim sektöründe yer almayı hedefleyen öğrenci ve mezunlar, bu dilde kendisini geliştirip uzmanlaşmak isteyen ve kariyerini bilişim sektöründe ilerletmek isteyenlerin tercih edebileceği bu eğitimde hedefimiz Sql Server Management Studio üzerinde az da olsa bilgi sahibi olan katılımcıların temel Sql bilgilerini arttırdıktan sonra trigger ve procedure gibi sektörde sık karşılaşacakları veritabanı nesneleri üzerinde çalışabilmelerini sağlamaktır.\r\n\r\n \r\n\r\nİkinci bölümde ise yazılımcının veritabanı bağımlılığını azaltan ve aynı zamanda bir ORM aracı olan Entity Framework Code First ile veritabanı tasarımı performans konusu ile birlikte güncel örnekler üzerinden anlatılır.", 1, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7744), "entity-frameworkcore-ile-egitim.png", true, false, 15, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7744), "Entity Framework Eğitimi", 65, 70.000m, "entity-framework-ile-egitim" },
                    { 7, "Bilişim  sektöründe yer almayı hedefleyen öğrenci ve mezunlar, bu dilde kendisini geliştirip uzmanlaşmak isteyen ve kariyerini bilişim sektöründe ilerletmek isteyenlerin tercih edebileceği bu eğitimde, katılımcılara .Net 4.6 teknolojisi ile C# diline giriş yaparak temel ilkelerin öğretilmesi amaçlanmıştır. Bu eğitim ile katılımcılar modüler programlamanın alt yapısını oluşturan Nesne Yönelimli Programlama (OOP) ile birlikte windows ortamında çalışan uygulamalar yaparak Microsoft Visual Studio ile yazılım geliştirici olma yolunda ilk adımı atarlar.\r\n\r\n \r\n\r\nC# nedir sorusuna gelirsek; Microsoft tarafından Visual Studio.Net ile birlikte geliştirilen, bu platformun tüm özelliklerinden yararlanmanızı sağlayan nesne tabanlı bir programlama dilidir. Öğrenilmesi  kolay, esnek, güvenli, çok yönlü ve modern bir yapıya sahiptir. C# ile birbirinden farklı yazılım programları kolayca kodlanabilmektedir.\r\n\r\n \r\n\r\nGünümüzde yazılım uygulamaları veritabanından bağımsız düşünülemez. Bu eğitim ile Microsoft'un veritabanı yönetimi için geliştirmiş olduğu Microsoft Sql Server Management Studio ile veritabanı yönetiminin incelikleri öğretilir. Program sonunda veritabanı ile entegre işlemler yapabilen ve windows ortamında çalışan uygulamalar geliştirebilirsiniz.", 1, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7746), "c-ile-egitim.png", true, false, 15, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7746), "C# Eğitimi", 165, 70.000m, "c#-ile-egitim" },
                    { 8, "Mobil uygulama geliştirme, kişisel dijital yardımcıları, kurumsal dijital yardımcıları veya cep telefonlarını içerebilen bir veya daha fazla mobil cihaz için bir mobil uygulamanın geliştirildiği eylem veya süreçtir.", 1, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7748), "mobil-uygulama-gelistirme-ile-egitim.png", true, false, 15, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7749), "Mobil Uygulama Geliştirme", 115, 70.000m, "mobil-uygulama-geliştirme-ile-egitim" },
                    { 9, "Bahçeşehir Üniversitesi | Wissen, Microsoft Gold Partner’i olarak Siber Güvenlik Uzmanlığı alanındaki eğitimlerini ileri seviye laboratuvarları ve uzman eğiticileri ile beraber gerçekleştirmektedir.Eğitim programımız başlamadan, kuralları bildiğinize ve kurallara uyacağınıza dair “Taahhütname” imzalamanız gerekmektedir.Doğru eğitim programını seçtiğinizden emin olunuz. Eğitim programlarımıza devamlılık zorunludur. Kurumun kabul edebileceği mazeretiniz olur ise Eğitim programlarının süresinin 1/10′ unu aşmamak üzere mazeret izni kullanabilirsiniz. Bu sürenin aşımı halinde, kursla ilişiğiniz kesilir.Eğitim programının başlangıcı itibariyle SGK, BAĞ-KUR veya Emekli Sandığı’ na bağlı olarak çalışıyorsanız eğitim programımıza katılamazsınız.Devam ettiğiniz her bir gün için 212.67 TL almaya hak kazanırsınız.Devam etmediğiniz günler için ödeme yapılmaz. Ödemeler açılacak banka hesabınıza aylık olarak yatırılır.İşsizlik sigortasından yararlanmakta iseniz kursa katılmanız halinde işsizlik sigortası ödemesi kesilmez (hak ettiğiniz kadar işsizlik ödeneğini ve kursa katıldığınız her gün için 212.67 TL‘yi almaya devam edersiniz).İşsizlik sigortasından yararlanmakta iken, geçerli bir gerekçe sunmadan katıldığınız kursu bırakmanız halinde bu tarihten itibaren işsizlik ödeneğiniz kesilir.Eğitim programı boyunca, ”Eğitim Maliyetleriniz” ile “İş Kazası ve Meslek Hastalığı Sigorta Priminiz” İŞKUR tarafından karşılanır.Eğitim aldığı programın uluslararası vendor sertifika sınavına bir defalığına ücretsiz katılım hakkı verilecektir.Eğitim aldığı programın uluslararası kitap ve materyali bir defalığına ücretsiz olarak verilecektir.", 1, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7750), "cyber-security-ile-egitim.png", true, false, 15, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7751), "cyber security", 600, 70.000m, "cyber-security-ile-egitim" },
                    { 10, "Bu eğitim katılımcılar Cloud yönetim ve işlemlerini gerçekleştirmek için gerekli bilgi ve yetenekleri,kazandırmak içindir. Katılımcılar Cloud yönetim yazılım çözümleri, Cloud alt yapısının temelleri, raporlama ve charge-back, Provision Clouds şablonları, Cloud yönetimi, izleme ve iyileştirme metodları, Cloud Özellikleri, kimlik denetimi, dağıtım modelleri hakkında bilgi sahibi olurlar.", 1, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7753), "cyber-security-ile-egitim.png", true, false, 15, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7753), "CCNA Cloud Yönetimi Eğitimi", 72, 70.000m, "cloud-yönetimi-egitimi" },
                    { 11, " \r\n\r\nCCNP Route Switching sertifikası alan kişi, yerel ve geniş ağları planlama, kurma, doğrulama ve sorun tespit etme ve problemleri giderme yetkinliklerine sahip olduğunu ortaya koymaktadır.\r\n\r\nRouting eğitimi alanlar, routing protokolleri ile güvenli kurumsal yerel ve geniş alan ağlarını planlamayı, kurmayı, konfigüre etmeyi ve doğrulamayı öğrenmektedir. Switch eğitimleri ile kompleks kurumsal switching planlaması, konfigürasyonu ve kurulumun doğrulanması öğretilmektedir.", 1, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7757), "cyber-security-ile-egitim.png", true, false, 15, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7757), "CCNP Route & Switching Eğitimi", 108, 70.000m, "ccnp-ile-egitim" },
                    { 12, "Bu eğitim Cisco Router ve Cisco Security ürünleri üzerinde gerçek senaryolara dayalı güvenlik tekniklerinin kullanılması ve yapılandırılmasını kapsar. Bu eğitim sonunda katılımcılar temel network güvenlik kavramları, Router ve Switch güvenliği, Kimlik Doğrulama, Firewall servisleri, Remote Access, izinsiz girişler ve içerik güvenliği konularında bilgi ve deneyim sahibi olacaklardır.", 1, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7759), "cyber-security-ile-egitim.png", true, false, 15, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7759), "CCNA Security Eğitimi", 165, 70.000m, "ccna-ile-egitim" },
                    { 13, "Java İle Android programlama eğitiminin ana hedefi Android işletim sisteminde çalışabilecek uygulamaların Java dili kullanılarak geliştirilmesidir. Bu eğitimimizde Java programlama dilinin temelleri detaylarıyla anlatılarak Android Studio yardımıyla Android uygulama geliştirmesi yapabilmeniz hedeflenmektedir.\r\n\r\n\r\n\r\nJava ve Android yazılım eğitiminde başlangıç düzeyindeki bir kişinin dahi anlayabileceği bir anlatım ve plan takip edilir. Kodlama dili ve işletim sistemindeki (Java ile Android uygulama geliştirmek adına gerekli) tüm detaylar aktarılır.\r\n\r\nAşama aşama sürdürülen eğitimlerle; kullanılan programlar, araçlar, modüller, kullanılan kod yapıları, hata yakalama ve yazılım test etme süreçleri aktarılır ve böylece programın ilk aşamadan son aşamaya kadar tüm bölümlerinde tam denetim yapabilecek yetkinliğe ulaşılır.", 1, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7761), "java-ile-android-egitim.png", true, false, 15, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7762), "Java ile Android Programlama", 165, 70.000m, "java-ile-android-egitim" },
                    { 14, "iOS işletim sistemi üzerinde çalışan mobil programların yazılmasında Swift programlama dili kullanılır. Bu programlama dili, zengin uygulama alanları kadar iş bulmayı kolaylaştırması açısından da yoğun ilgi görür. Açık kaynak olan Swift kodları, programcıların dikkatini çeker.\r\n\r\n \r\n\r\nSwift dersleri ve iOS programlama eğitimi ile mobil cihazlar için kodlama yapabilir, farklı alanlarda çalışabilirsiniz. Mobil programlama ile kendi firmanızın ihtiyacı olan spesifik bir uygulamayı ya da herkesin kullanabileceği genel bir programı kolayca geliştirebilirsiniz.\r\n\r\n \r\n\r\nSwift programlama dili, macOS, iOS, watchOS ve tvOS işletim sistemlerinde kullanılan sezgisel ve güçlü bir programlama dilidir. Kodlaması kolay ve keyifli bir dildir. Modern özellikler taşıyan Swift kodları, etkileşimli ve eğlenceli bir yapı sunar. Tasarımsal olarak güvenli bir yapıya sahip olan Swift kodu, oldukça hızlı çalışan programlar yazmaya olanak tanır.\r\n\r\n \r\n\r\nMobil programlama, küçük kablosuz cihazlar için kodlanan yazılımlardır. Bu programlar, yazıldıkları cihazlarda bulunan diğer bileşenleri kullanabilir. Örneğin; akıllı saat üzerinde çalışması düşünülen bir sağlık uygulaması, cihaz üzerinde bulunan sıcaklık sensörünü kullanabilir. Bu doğrultuda, mobil programlama dilleri; cihazda daha az yer tutan, daha az enerji harcayan ve hızlı çalışan kodları hedefleyerek geliştirilir.\r\n\r\n \r\n\r\nSwift programlama dili, jenerik yapısıyla güçlü ve kolay bir kullanım sunar. Protokol uzantıları sayesinde jenerik kodlar yazmak çok daha kolaylaşır. Swift, metodları, uzantıları ve protokolleri destekleyen bir yapıya sahiptir.\r\n\r\n \r\n\r\nSwift programlama dilini öğrenirken Swift oyun alanı (Swift playgrounds) iOS uygulamasında bulmacalar çözmek için gerçek Swift kodlarını kullanabilirsiniz. Böylece mobil programlamayı eğlenceli hale de getirebilirsiniz.", 1, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7763), "Swift-ile-egitim.jpg", true, false, 15, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7764), "Swift ile iOS Mobil Programlama Eğitimi", 165, 70.000m, "swift-ile-egitim" },
                    { 15, "Modern zamanın petrolü olarak kabul edilen verinin yakalanması, güvenli olarak saklanması, depolanması, yönetilmesi, programlanması, analiz edilmesi ve raporlanması tüm işletmeler için çok önemli hale gelmiştir. Verinin artan hacmi, türü ve oluşma hızı nedeniyle geleneksel yöntemlere ek olarak yeni nesil veri tabanları ve bulut teknolojiler gibi farklı mecralarda çalışma ihtiyaçları doğmuştur. Bu bağlamda piyasada veri mühendisi, veri bilimcisi, veri analisti, raporlama uzmanı ve veri tabanı yöneticisi gibi roller her zamankinden daha fazla talep edilir olmuştur. Bu eğitimle veriyle ilgili tüm parçalara derinlemesine girilip hem geleneksel veri tabanlarına hem büyük veri sistemlerine hem de bulut tabanlı veri tabanlarına hakim olunması sağlanacak ve katılımcılara veri ile ilgili bütünsel bir uzmanlık kazandırılacaktır.", 1, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7766), "full-data-ile-egitim.png", true, false, 15, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7766), "Full Data Uzmanlık Eğitimi", 400, 70.000m, "full-data-ile-egitim" },
                    { 16, "Bulut bilişim, bilgi işlem hizmetlerinin (sunucu, depolama, veri tabanı, ağ, yazılım, analiz ve makine zekası dahil) internet -bulut- üzerinden sağlanarak daha hızlı inovasyon, esnek kaynaklar ve ekonomik ölçeklendirme sunulması anlamına gelir. Normalde yalnızca kullandığınız bulut hizmetleri için ödeme yaptığınızdan işletim maliyetlerinizi düşürebilir, altyapınızı daha verimli bir şekilde çalıştırabilir ve değişen iş gereksinimlerinize uygun şekilde ölçeklendirme yapabilirsiniz.\r\n\r\nGünümüzde birçok kurum bulut teknolojisini kullanır ve birçok uzman bu devrim niteliğindeki bilgi işlem eğiliminin konsepti ile ilgili geliştirmeler yapar. Bulut bilgi işlem, işletmelerin BT kaynaklarına bakış açısını önemli ölçüde değiştirdi. Kurumlar, maliyet, küresel ölçeklendirme, performans, hız ve verimlilik gibi avantajları nedeniyle bulut bilişim hizmetlerine oldukça ilgi duymaktadırlar.", 1, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7768), "bulut-ile-egitim.jpg", true, false, 15, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7768), "Bulut Bilişim Uzmanlık Eğitimi", 165, 70.000m, "bulut-ile-egitim" },
                    { 17, "İleri Düzey SEO Eğitimi ile web sitesi sahipleri için olmazsa olmaz olan Arama Motoru Optimizasyonu(SEO)' nun temellerini kazanmış olacaksınız.İleri düzey teknikler hakkında da bilgi sahibi olacaksınız. Böylece rakip internet siteleri arasından sıyrılarak bir web sitesini Google gibi arama motorlarında başarılı hale getirmenin yöntemlerini öğrenmiş olacaksınız. Seo uyumlu içerik üretimi konusunda bilgiler öğreneceksiniz.", 1, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7770), "seo-ile-egitim.jpg", true, false, 6, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7771), "Arama Motoru Optimizasyonu (SEO) Eğitimi", 35, 27.000m, "seo-ile-egitim" },
                    { 18, "İleri Düzey SEO Eğitimi ile web sitesi sahipleri için olmazsa olmaz olan Arama Motoru Optimizasyonu(SEO)' nun temellerini kazanmış olacaksınız.İleri düzey teknikler hakkında da bilgi sahibi olacaksınız. Böylece rakip internet siteleri arasından sıyrılarak bir web sitesini Google gibi arama motorlarında başarılı hale getirmenin yöntemlerini öğrenmiş olacaksınız. Seo uyumlu içerik üretimi konusunda bilgiler öğreneceksiniz.", 1, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7773), "logo-tasarımı-ile-egitim.jpg", true, false, 6, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7773), "Logo Tasarımı", 27, 16.000m, "logo-tasarımı-ile-egitim" },
                    { 19, "İleri Düzey SEO Eğitimi ile web sitesi sahipleri için olmazsa olmaz olan Arama Motoru Optimizasyonu(SEO)' nun temellerini kazanmış olacaksınız.İleri düzey teknikler hakkında da bilgi sahibi olacaksınız. Böylece rakip internet siteleri arasından sıyrılarak bir web sitesini Google gibi arama motorlarında başarılı hale getirmenin yöntemlerini öğrenmiş olacaksınız. Seo uyumlu içerik üretimi konusunda bilgiler öğreneceksiniz.", 1, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7775), "html-css-js-ile-egitim.png", true, false, 12, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7775), "Html,Css,Js Eğitimi", 65, 55.000m, "html-css-js-ile-egitim" },
                    { 20, "Bu eğitimin amacı mevcut javascript programlama dili bilginizle nodejs kullanarak sıfırdan dinamik web uygulamalarını geliştirebilecek bilgi ve beceriyi kazandırmaktır.", 1, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7777), "node-ile-egitim.png", true, false, 12, new DateTime(2023, 7, 28, 6, 59, 28, 160, DateTimeKind.Local).AddTicks(7777), "Node.js ile Web Programlama", 65, 55.000m, "node-ile-egitim" }
                });

            migrationBuilder.InsertData(
                table: "CategoriesLessons",
                columns: new[] { "CategoryId", "LessonId", "AgenciesId" },
                values: new object[,]
                {
                    { 1, 1, null },
                    { 2, 1, null },
                    { 5, 1, null },
                    { 2, 2, null },
                    { 5, 2, null },
                    { 3, 3, null },
                    { 6, 4, null },
                    { 2, 5, null },
                    { 8, 5, null },
                    { 3, 6, null },
                    { 2, 7, null },
                    { 5, 7, null },
                    { 8, 7, null },
                    { 6, 8, null },
                    { 8, 9, null },
                    { 9, 9, null },
                    { 9, 10, null },
                    { 9, 11, null },
                    { 9, 12, null },
                    { 6, 13, null },
                    { 4, 14, null },
                    { 3, 15, null },
                    { 4, 16, null },
                    { 7, 17, null },
                    { 7, 18, null },
                    { 1, 19, null },
                    { 5, 19, null },
                    { 5, 20, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgenciesCategory_CategoryId",
                table: "AgenciesCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesLessons_AgenciesId",
                table: "CategoriesLessons",
                column: "AgenciesId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesLessons_CategoryId",
                table: "CategoriesLessons",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_AgenciesId",
                table: "Lessons",
                column: "AgenciesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgenciesCategory");

            migrationBuilder.DropTable(
                name: "CategoriesLessons");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Agencies");
        }
    }
}
