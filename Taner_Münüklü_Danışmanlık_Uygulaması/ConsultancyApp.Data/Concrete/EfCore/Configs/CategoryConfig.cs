using ConsultancyApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultancyApp.Data.Concrete.EfCore.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.About).IsRequired();
            builder.Property(c => c.Url).IsRequired();
            
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.AgenciesId).IsRequired();


            builder.HasData(new Category
            {
                Id=1,
                Name= "frontend",
                 Url="frontend-ile-ilgili-egitim",
                  IsActive=true,
                  IsDeleted=false,
                   About="Burada frontend egitimleri veriliyor",
                     

            },new Category
            {
                Id=2,
                Name= "Backend Egitimi",
                Url="backend-ile-ilgili-egitim",
                IsActive=true,
                IsDeleted=false,
                About="Burada backend  egitimleri veriliyor"
            },new Category
            {
                Id=3,
                Name="Veritabanı Egitimi",
                Url="veri-tabanı-ile-ilgili-egitim",
                IsActive=true,
                IsDeleted=false,
                About="Burada veritabanı Egitimleri veriliyor"
            },new Category
            {
                Id=4,
                Name="Bulut bilişimler ve ios",
                Url="bulut-bilisimler-ve-ios-ile-egitim",
                IsActive=true,
                IsDeleted=false,
                About="Burada veritabanlı  egitimleri veriliyor."

            },new Category
            {
                Id=5,
                Name="Web App",
                Url="web-app-ile-egitim",
                IsActive=true,
                IsDeleted=false,
                About="Burada Android programların egitimi verilecek"
            },new Category
            {
                Id=6,
                Name="Oyun ve Android Programlama",
                Url="oyun-ve-android-programlama-ile-egitim",
                IsActive=true,
                IsDeleted=false,
                About="Burada Veri analizi ve ios programlama egitimleri veriliyor"
            },new Category
            {
                Id=7,
                Name="Reklam ve Pazarlama",
                Url="reklam-pazarlama-ile-egitim",
                IsDeleted=false,
                IsActive=true,
                About="Seo optimazsonu ve reklam tekniklerini ögreten ve logo oluşturmayı ögreten bir firma",
            },new Category
            {
                Id=8,
                Name=".Net Egitimi",
                Url="dotnet--ile-egitim",
                IsActive=true,
                IsDeleted=false,
                About="Burada dotnet egitimleri verilecek"
            }
            , new Category
            {
                Id = 9,
                Name = "CyberSecurity",
                Url = "cyber-security-ile-egitim",
                IsActive = true,
                IsDeleted = false,
                About = "Burada güvenlik egitimleri verilecek"
            }

            );
      

        }
    }
}
