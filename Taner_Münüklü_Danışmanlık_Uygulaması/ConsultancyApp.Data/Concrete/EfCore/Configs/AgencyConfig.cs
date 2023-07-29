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
    public class AgencyConfig : IEntityTypeConfiguration<Agencies>
    {
        public void Configure(EntityTypeBuilder<Agencies> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Url).IsRequired();
            builder.Property(a => a.City).IsRequired();
            builder.Property(a => a.About).IsRequired();
            builder.Property(a => a.Price).IsRequired();
            builder.Property(a => a.FoundationYear).IsRequired();
            builder.Property(a => a.LessonId).IsRequired();
            builder.Property(a => a.ImageUrl).IsRequired();

            builder.HasData(new Agencies
            {
                Id = 1,
                Name = "Genel",
                Url = "genel-egitim-kurumu",
                ImageUrl= "genel-egitim-kurumu",
                City = "İstanbul",
                About = "bu bir silinmiş ajansların bulunacağı kısımdır.",
                Price = 0,
                FoundationYear = 1,
                LessonId = 1,




            },new Agencies
            {
                Id = 12,
                Name = "Mellon",
                Url = "mellon-egitim-kurumu",
                ImageUrl = "mellon-egitim-kurumu",
                City = "İstanbul",
                About = "bu bir frontend firmasıdır",
                Price = 150.000,
                FoundationYear = 2000,
                LessonId = 19,




            }, new Agencies
            {
                Id = 2,
                Name = "Ferisoft",
                Url = "ferisoft-egitim-kurumu",
                ImageUrl= "ferisoft-egitim-kurumu",
                City = "İstanbul",
                About = "bu bir backend egitimi veren  firmadır",
                Price = 150.000,
                FoundationYear = 2000,
                LessonId = 19,
            }, new Agencies
            {
                Id = 3,
                Name = "Evkal",
                Url = "evkal-egitim-kurumu",
                ImageUrl= "evkal-egitim-kurumu",
                City = "İstanbul",
                About = "bu bir veri tabanı firmasıdır",
                Price = 150.000,
                FoundationYear = 2000,
                LessonId = 19,
            }, new Agencies
            {
                Id = 4,
                Name = "Appricot",
                Url = "appricot-egitim-kurumu",
                ImageUrl= "appricot-egitim-kurumu",
                City = "İstanbul",
                About = "bu bir Android programlama firmasıdır",
                Price = 150.000,
                FoundationYear = 2000,
                LessonId = 19,
            }, new Agencies
            {
                Id = 5,
                Name = "Appwox",
                Url = "appwox-egitim-kurumu",
                ImageUrl= "appwox-egitim-kurumu",
                City = "İstanbul",
                About = "bu bir IOS ve bulut bilişim egitim firmasıdır",
                Price = 150.000,
                FoundationYear = 2000,
                LessonId = 19,
            }, new Agencies
            {
                Id = 6,
                Name = "Taze",
                Url = "taze-egitim-kurumu",
                ImageUrl= "taze-egitim-kurumu",
                City = "İstanbul",
                About = "bu bir Cybersecurity firmasıdır",
                Price = 150.000,
                FoundationYear = 2000,
                LessonId = 19,
            }, new Agencies
            {
                Id = 7,
                Name = "House Of Apps",
                Url = "house-of-apps-egitim-kurumu",
                ImageUrl= "house-of-apps-egitim-kurumu",
                City = "İstanbul",
                About = "bu bir Tasarım firmasıdır",
                Price = 150.000,
                FoundationYear = 2000,
                LessonId = 19,
            }, new Agencies
            {
                Id = 8,
                Name = "Westerops",
                Url = "westerops-egitim-kurumu",
                ImageUrl= "westerops-egitim-kurumu",
                City = "İstanbul",
                About = "bu bir web application egitim firmasıdır",
                Price = 150.000,
                FoundationYear = 2000,
                LessonId = 19,
            }, new Agencies
            {
                Id = 9,
                Name = "Vayes",
                Url = "vayes-egitim-kurumu",
                ImageUrl= "vayes-egitim-kurumu",
                City = "İstanbul",
                About = "bu bir oyun programlama firmasıdır",
                Price = 100.000,
                FoundationYear = 2002,
                LessonId = 19,
            }, new Agencies
            {
                Id = 10,
                Name = "Cremıcro",
                Url = "cremicro-egitim-kurumu",
                ImageUrl= "cremicro-egitim-kurumu",
                City = "İstanbul",
                About = "bu bir Cybersecurity egitim firmasıdır",
                Price = 355.000,
                FoundationYear = 1975,
                LessonId = 19,
            }, new Agencies
            {
                Id = 11,
                Name = "galta media",
                Url = "galta-media-egitim-kurumu",
                ImageUrl= "galta-media-egitim-kurumu",
                City = "İstanbul",
                About = "bu bir Tasarım ve Marka oluşturma firmasıdır",
                Price = 150.000,
                FoundationYear = 2005,
                LessonId = 19,
            }
            ) ;


        }
    }
}
