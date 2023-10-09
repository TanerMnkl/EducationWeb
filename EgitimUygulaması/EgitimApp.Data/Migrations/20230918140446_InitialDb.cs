using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EgitimApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    About = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
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
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: false),
                    Adress = table.Column<string>(type: "TEXT", nullable: false),
                    About = table.Column<string>(type: "TEXT", nullable: false),
                    Contact = table.Column<int>(type: "INTEGER", nullable: false),
                    QuestionAsked = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Education = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Specialties = table.Column<string>(type: "TEXT", nullable: false),
                    Experience = table.Column<string>(type: "TEXT", nullable: false),
                    About = table.Column<string>(type: "TEXT", nullable: false),
                    Evaluation = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    BirthOfYear = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseName = table.Column<string>(type: "TEXT", nullable: false),
                    TotalCourseHour = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalCourseMonthly = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    About = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<int>(type: "INTEGER", nullable: false),
                    LevelofEducation = table.Column<string>(type: "TEXT", nullable: false),
                    AchievementsOfEducation = table.Column<string>(type: "TEXT", nullable: false),
                    LocationofEducation = table.Column<string>(type: "TEXT", nullable: false),
                    EducationContents = table.Column<string>(type: "TEXT", nullable: false),
                    EducationOfEvaluation = table.Column<int>(type: "INTEGER", nullable: false),
                    EducationStatus = table.Column<string>(type: "TEXT", nullable: false),
                    TrainerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursesCategories",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesCategories", x => new { x.CourseId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_CoursesCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesCategories_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursesTrainees",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    TraineeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesTrainees", x => new { x.CourseId, x.TraineeId });
                    table.ForeignKey(
                        name: "FK_CoursesTrainees_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesTrainees_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "About", "CreatedDate", "IsActive", "IsDeleted", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Yazılım geliştirme, bilgisayar programlarının tasarımı, oluşturulması ve sürdürülmesi sürecidir. Bu süreç, kullanıcı ihtiyaçlarını karşılamak, işlevsellik sağlamak ve teknolojik çözümler üretmek için kodlama, test etme ve dağıtma adımlarını içerir.", new DateTime(2023, 9, 18, 17, 4, 46, 797, DateTimeKind.Local).AddTicks(5169), true, false, new DateTime(2023, 9, 18, 17, 4, 46, 797, DateTimeKind.Local).AddTicks(5177), "Yazılım Geliştime", "yazilim-gelistirme" },
                    { 2, "Mobil uygulama geliştirme, mobil platformlarda çalışabilen kullanışlı ve etkileşimli yazılım uygulamalarının tasarımı, oluşturulması ve dağıtılması sürecidir. Bu süreç, kullanıcı ihtiyaçlarını karşılamak, sorunlara çözüm sunmak ve kullanıcı deneyimini geliştirmek için programlama, arayüz tasarımı, test etme ve dağıtma adımlarını içerir.", new DateTime(2023, 9, 18, 17, 4, 46, 797, DateTimeKind.Local).AddTicks(5180), true, false, new DateTime(2023, 9, 18, 17, 4, 46, 797, DateTimeKind.Local).AddTicks(5180), "Mobil Uygulama Geliştirme", "mobil-uygulama-gelistirme" },
                    { 3, "Oyun geliştirme, video oyunlarının tasarımı, programlaması ve oluşturulması sürecidir. Bu süreç, oyun kavramının belirlenmesi, hikaye yazımı, karakter tasarımı, dünya oluşturma, grafik ve ses tasarımı, oyun mekaniği ve kullanıcı arayüzü gibi aşamaları içerir.", new DateTime(2023, 9, 18, 17, 4, 46, 797, DateTimeKind.Local).AddTicks(5181), true, false, new DateTime(2023, 9, 18, 17, 4, 46, 797, DateTimeKind.Local).AddTicks(5182), "Oyun Geliştime", "oyun-gelistirme" },
                    { 4, "Web, dünya genelinde bilgilere erişim sağlayan ve kullanıcıların çeşitli hizmetlere bağlanmasını mümkün kılan bir ağdır. Web, HTML, CSS ve JavaScript gibi teknolojilerle oluşturulan web siteleri ve web uygulamaları aracılığıyla çalışır.", new DateTime(2023, 9, 18, 17, 4, 46, 797, DateTimeKind.Local).AddTicks(5182), true, false, new DateTime(2023, 9, 18, 17, 4, 46, 797, DateTimeKind.Local).AddTicks(5183), "Web", "web" },
                    { 5, "Veritabanı, yapılandırılmış verilerin depolandığı ve yönetildiği bir elektronik sistemdir. Veritabanları, bilgiyi organize etmek, erişmek, güncellemek ve analiz etmek için kullanılır. İşletmeler, kuruluşlar ve web uygulamaları gibi birçok alan veritabanlarını kullanır.", new DateTime(2023, 9, 18, 17, 4, 46, 797, DateTimeKind.Local).AddTicks(5183), true, false, new DateTime(2023, 9, 18, 17, 4, 46, 797, DateTimeKind.Local).AddTicks(5184), "Veritabanı", "veritabani" },
                    { 6, "DevOps, yazılım geliştirme ve işletim süreçlerini birleştirerek, yazılım projelerinin daha hızlı, güvenilir ve sürekli bir şekilde dağıtılmasını sağlayan bir yaklaşımdır. Bu metodoloji, geliştirme (Development) ve işletim (Operations) ekipleri arasında işbirliği ve iletişimi teşvik eder.", new DateTime(2023, 9, 18, 17, 4, 46, 797, DateTimeKind.Local).AddTicks(5185), true, false, new DateTime(2023, 9, 18, 17, 4, 46, 797, DateTimeKind.Local).AddTicks(5185), "DevOps", "devops" },
                    { 7, "Bulut, internet üzerinde sunulan paylaşımlı bilgi işlem kaynaklarını ifade eder. Bulut hizmetleri, sunucular, depolama, veritabanları, ağ altyapısı ve uygulama hizmetleri gibi kaynaklara erişimi kolaylaştırır. Kullanıcılar, istedikleri zaman istedikleri yerden bu kaynaklara güvenli bir şekilde erişebilir ve ihtiyaçlarına göre ölçeklendirebilir.", new DateTime(2023, 9, 18, 17, 4, 46, 797, DateTimeKind.Local).AddTicks(5186), true, false, new DateTime(2023, 9, 18, 17, 4, 46, 797, DateTimeKind.Local).AddTicks(5186), "Bulut", "bulut" }
                });

            migrationBuilder.InsertData(
                table: "Trainees",
                columns: new[] { "Id", "CreatedDate", "Education", "FirstName", "IsActive", "IsDeleted", "LastName", "ModifiedDate", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(2523), ".NET (.NET Core, MVC, Web API)", "Taner", true, false, "Münüklü", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(2526), "taner-munuklu" },
                    { 2, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(2528), "Java (Spring, Java SE, Java EE)", "Serkan", true, false, "Selek", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(2528), "serkan-selek" },
                    { 3, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(2529), "Python", "Furkan", true, false, "Yüksel", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(2530), "furkan-yuksel" },
                    { 4, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(2531), "JavaScript", "Selimcan", true, false, "Engin", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(2531), "selo-engin" },
                    { 5, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(2532), "C/C++", "Emre", true, false, "Candar", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(2532), "emre-candar" },
                    { 6, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(2534), "iOS & Android", "Atahan", true, false, "Akıncı", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(2534), "atahan-akıncı" },
                    { 7, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(2535), "Node.js", "Alper", true, false, "Karateke", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(2536), "alper-karateke" },
                    { 8, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(2537), "React", "Ali", true, false, "Münüklü", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(2537), "ali-munuklu" }
                });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "About", "BirthOfYear", "CreatedDate", "Evaluation", "Experience", "FirstName", "IsActive", "IsDeleted", "LastName", "ModifiedDate", "Specialties", "Url" },
                values: new object[,]
                {
                    { 1, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1990, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4459), 1, "", "Dominic", true, false, "Harmon", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4461), "C#", "dominic-harmon" },
                    { 2, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1991, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4465), 1, "", "Justina", true, false, "Burch", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4466), "C#", "" },
                    { 3, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1991, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4468), 1, "", "Madison", true, false, "Beard", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4468), "C#", "" },
                    { 4, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1991, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4469), 1, "", "Sara", true, false, "Wade", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4470), "C#", "" },
                    { 5, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1991, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4471), 1, "", "Jacob", true, false, "Hunt", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4471), "C#", "" },
                    { 6, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1989, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4473), 1, "", "Osamu", true, false, "Dazai", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4473), "C#", "" },
                    { 7, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1983, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4474), 1, "", "Zachery", true, false, "Salas", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4474), "C#", "" },
                    { 8, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1982, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4476), 1, "", "Matt", true, false, "Haig", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4476), "C#", "" },
                    { 9, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1982, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4477), 1, "", "William", true, false, "Hawkingan", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4478), "C#", "" },
                    { 10, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1990, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4479), 1, "", "Geraldine", true, false, "Richmond", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4479), "C#", "" },
                    { 11, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1983, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4480), 1, "", "Steffan", true, false, "Ros", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4481), "C#", "" },
                    { 12, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1991, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4482), 1, "", "Nichole", true, false, "Talley", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4482), "C#", "" },
                    { 13, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1979, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4484), 1, "", "Yetta", true, false, "Sheppard", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4484), "C#", "" },
                    { 14, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1978, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4485), 1, "", "Elijah", true, false, "Farley", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4485), "C#", "" },
                    { 15, "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.", 1991, new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4487), 1, "", "Neil", true, false, "Wooten", new DateTime(2023, 9, 18, 17, 4, 46, 799, DateTimeKind.Local).AddTicks(4487), "C#", "" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "About", "AchievementsOfEducation", "CourseName", "CreatedDate", "EducationContents", "EducationOfEvaluation", "EducationStatus", "EndTime", "ImageUrl", "IsActive", "IsDeleted", "LevelofEducation", "LocationofEducation", "ModifiedDate", "Price", "StartTime", "TotalCourseHour", "TotalCourseMonthly", "TrainerId", "Url" },
                values: new object[,]
                {
                    { 1, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", ".NET (.NET Core, MVC, Web API)", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(107), "Yazılım dersi", 5, "Tamamlandı", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(114), "1.jpg", true, false, "Easy", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(109), 700, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(113), 600, 6, 1, ".net-core-mvc" },
                    { 2, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "Java (Spring, Java SE, Java EE)", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(120), "Yazılım dersi", 5, "Tamamlandı", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(122), "2.jpg", true, false, "Easy", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(121), 200, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(121), 600, 6, 2, "java" },
                    { 3, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "Python", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(125), "Yazılım dersi", 5, "Tamamlandı", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(126), "3.jpg", true, false, "Easy", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(125), 700, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(126), 200, 6, 3, "python" },
                    { 4, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "JavaScript", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(128), "Yazılım dersi", 5, "Tamamlandı", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(129), "4.jpeg", true, false, "Easy", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(128), 700, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(129), 200, 6, 4, "javascript" },
                    { 5, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "C/C++", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(131), "Yazılım dersi", 5, "Tamamlandı", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(132), "5.jpg", true, false, "Easy", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(131), 100, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(132), 200, 6, 5, "c/c++" },
                    { 6, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "iOS & Android", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(134), "Yazılım dersi", 5, "Açılacak", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(136), "6.png", true, false, "Easy", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(134), 100, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(135), 300, 6, 6, "ios-android" },
                    { 7, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma", "React Native", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(137), "Yazılım dersi", 5, "Açılacak", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(139), "7.png", true, false, "Easy", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(137), 100, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(139), 600, 6, 7, "react-native" },
                    { 8, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "Flutter", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(141), "Yazılım dersi", 5, "Tamamlandı", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(142), "8.png", true, false, "Easy", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(141), 700, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(142), 600, 6, 8, "flutter" },
                    { 9, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "Ionic", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(144), "Yazılım dersi", 5, "Açılacak", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(145), "9.jpg", true, false, "Easy", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(144), 100, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(145), 200, 6, 9, "ionic" },
                    { 10, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "Unity", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(147), "Yazılım dersi", 5, "Tamamlandı", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(148), "10.jpeg", true, false, "Easy", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(147), 300, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(148), 200, 6, 10, "unity" },
                    { 11, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma", "Unreal Engine", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(150), "Yazılım dersi", 5, "Açılacak", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(151), "11.png", true, false, "Medium", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(150), 100, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(151), 600, 6, 11, "unreal-engine" },
                    { 12, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "GameMaker Studio", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(152), "Yazılım dersi", 5, "Açılacak", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(154), "12.png", true, false, "Medium", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(153), 700, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(153), 200, 6, 12, "gamemaker-studio" },
                    { 13, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "Buildbox", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(155), "Yazılım dersi", 5, "Açılacak", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(157), "13.jpeg", true, false, "Medium", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(156), 700, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(156), 400, 4, 13, "buildbox" },
                    { 14, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "PHP", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(158), "Yazılım dersi", 5, "Tamamlandı", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(161), "14.png", true, false, "Medium", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(159), 700, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(160), 600, 6, 14, "php" },
                    { 15, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "React", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(162), "Yazılım dersi", 5, "Tamamlandı", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(163), "15.jpeg", true, false, "Easy", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(162), 700, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(163), 200, 3, 8, "react" },
                    { 16, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "Angular", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(165), "Yazılım dersi", 5, "Tamamlandı", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(166), "16.png", true, false, "Medium", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(165), 700, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(166), 400, 4, 9, "angular" },
                    { 17, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "Node.js", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(168), "Yazılım dersi", 5, "Tamamlandı", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(170), "17.png", true, false, "Medium", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(169), 700, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(169), 400, 4, 10, "nodejs" },
                    { 18, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "Microsoft SQL Server", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(171), "Yazılım dersi", 5, "Tamamlandı", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(173), "18.jpg", true, false, "Medium", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(171), 700, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(172), 600, 6, 11, "microsoft-sql-server" },
                    { 19, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "MySQL", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(174), "Yazılım dersi", 5, "Tamamlandı", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(175), "19.png", true, false, "Medium", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(174), 100, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(175), 100, 2, 12, "mysql" },
                    { 20, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "PostgreSQL", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(177), "Yazılım dersi", 5, "Tamamlandı", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(180), "20.png", true, false, "Medium", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(177), 100, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(180), 600, 6, 13, "postgresql" },
                    { 21, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "SQLite", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(181), "Yazılım dersi", 5, "Açılacak", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(183), "21.png", true, false, "Senior", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(182), 300, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(182), 300, 3, 11, "sqlite" },
                    { 22, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "Oracle", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(185), "Yazılım dersi", 5, "Devam Ediyor", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(187), "22.png", true, false, "Senior", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(185), 700, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(186), 400, 4, 12, "oracle" },
                    { 23, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "Docker", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(189), "Yazılım dersi", 5, "Devam Ediyor", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(190), "23.png", true, false, "Senior", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(189), 100, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(190), 200, 2, 13, "docker" },
                    { 24, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "Jenkins", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(191), "Yazılım dersi", 5, "Devam Ediyor", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(193), "24.png", true, false, "Senior", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(192), 400, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(192), 400, 4, 14, "jenkins" },
                    { 25, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "Ansible", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(194), "Yazılım dersi", 5, "Devam Ediyor", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(196), "25.png", true, false, "Senior", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(195), 700, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(195), 200, 6, 8, "ansible" },
                    { 26, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma,Web Geliştirme", "Sonarcube", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(197), "Yazılım dersi", 5, "Devam ediyor", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(199), "26.jpeg", true, false, "Senior", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(197), 700, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(198), 200, 6, 9, "sonarcube" },
                    { 27, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma", "AWS", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(200), "Yazılım dersi", 5, "Devam Ediyor", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(201), "27.png", true, false, "Senior", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(200), 700, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(201), 600, 6, 10, "aws" },
                    { 28, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma", "Azure", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(203), "Yazılım dersi", 5, "Devam Ediyor", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(204), "28.png", true, false, "Senior", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(203), 700, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(204), 600, 6, 11, "azure" },
                    { 29, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma", "Serverless", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(206), "Yazılım dersi", 5, "Devam Ediyor", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(207), "29.png", true, false, "Easy", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(206), 700, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(207), 600, 6, 12, ".net-core-mvc" },
                    { 30, "Yazılım dersi, bilgisayar bilimlerinin önemli bir alanıdır ve öğrencilere temel bilgisayar programlama, algoritma oluşturma, veri yapıları, yazılım mühendisliği ve uygulama geliştirme konularında bilgi sağlar. Bu ders, öğrencilere problem çözme becerileri kazandırarak mantıksal düşünce ve analitik yeteneklerini geliştirir. Yazılım dersi aynı zamanda modern teknoloji dünyasında önemli bir role sahip olan yazılım süreçlerini, proje yönetimini ve test etme yöntemlerini de kapsar. Öğrenciler, çeşitli programlama dilleri ve yazılım araçlarını kullanarak uygulamalar geliştirerek pratik deneyim elde eder. Bu ders, gelecekteki teknoloji liderleri ve yazılım geliştiricileri için temel bir adımdır.", "Kod yazma", "Cloud Storage", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(231), "Yazılım dersi", 5, "Devam Ediyor", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(233), "30.png", true, false, "Easy", "Barbaros Bulvarı Yıldız İş Hanı No: 9 Kat: 3 Beşiktaş - İstanbul", new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(232), 100, new DateTime(2023, 9, 18, 17, 4, 46, 798, DateTimeKind.Local).AddTicks(233), 600, 6, 12, "cloud-storage" }
                });

            migrationBuilder.InsertData(
                table: "CoursesCategories",
                columns: new[] { "CategoryId", "CourseId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 2, 8 },
                    { 2, 9 },
                    { 3, 10 },
                    { 3, 11 },
                    { 3, 12 },
                    { 3, 13 },
                    { 4, 14 },
                    { 4, 15 },
                    { 4, 16 },
                    { 4, 17 },
                    { 5, 18 },
                    { 5, 19 },
                    { 5, 20 },
                    { 5, 21 },
                    { 5, 22 },
                    { 6, 23 },
                    { 6, 24 },
                    { 6, 25 },
                    { 6, 26 },
                    { 7, 27 },
                    { 7, 28 },
                    { 7, 29 },
                    { 7, 30 }
                });

            migrationBuilder.InsertData(
                table: "CoursesTrainees",
                columns: new[] { "CourseId", "TraineeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 2 },
                    { 8, 2 },
                    { 9, 2 },
                    { 10, 3 },
                    { 11, 3 },
                    { 12, 3 },
                    { 13, 3 },
                    { 14, 4 },
                    { 15, 4 },
                    { 16, 4 },
                    { 17, 4 },
                    { 18, 5 },
                    { 19, 5 },
                    { 20, 5 },
                    { 21, 5 },
                    { 22, 5 },
                    { 23, 6 },
                    { 24, 6 },
                    { 25, 6 },
                    { 26, 6 },
                    { 27, 7 },
                    { 28, 7 },
                    { 29, 7 },
                    { 30, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TrainerId",
                table: "Courses",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesCategories_CategoryId",
                table: "CoursesCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesTrainees_TraineeId",
                table: "CoursesTrainees",
                column: "TraineeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursesCategories");

            migrationBuilder.DropTable(
                name: "CoursesTrainees");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Trainees");

            migrationBuilder.DropTable(
                name: "Trainers");
        }
    }
}
