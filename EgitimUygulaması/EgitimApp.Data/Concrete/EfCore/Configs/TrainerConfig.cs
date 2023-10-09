using EgitimApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Data.Concrete.EfCore.Configs
{
    public class TrainerConfig : IEntityTypeConfiguration<Trainer>
    {
        public void Configure(EntityTypeBuilder<Trainer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedDate).IsRequired();

            builder.Property(x => x.ModifiedDate).IsRequired();

            builder.Property(x => x.IsActive).IsRequired();

            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.FirstName).IsRequired();

            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.BirthOfYear).IsRequired();

            builder.Property(x => x.Specialties).IsRequired();

            builder.Property(x => x.Evaluation).IsRequired();

            builder.Property(x => x.Url).IsRequired();

            builder.Property(x => x.About).IsRequired();

            builder.HasData(
                new Trainer
                {
                    Id = 1,
                    FirstName = "Dominic",
                    LastName = "Harmon",
                    Url = "dominic-harmon",
                    Experience = "",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",
                    Evaluation = 1,
                    BirthOfYear = 1990,
                    Specialties = "C#"

                },
                new Trainer
                {
                    Id = 2,
                    FirstName = "Justina",
                    LastName = "Burch",
                    BirthOfYear = 1991,
                    Specialties = "C#",



                    Experience = "",
                    Url = "",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",

                    Evaluation = 1
                },
                 new Trainer
                 {
                     Id = 3,
                     FirstName = "Madison",
                     LastName = "Beard",
                     BirthOfYear = 1991,
                     Specialties = "C#",
                     Experience = "",
                     Url = "",
                     About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",

                     Evaluation = 1
                 },
                new Trainer
                {
                    Id = 4,
                    FirstName = "Sara",
                    LastName = "Wade",
                    BirthOfYear = 1991,
                    Specialties = "C#",
                    Experience = "",
                    Url = "",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",

                    Evaluation = 1
                },
                new Trainer
                {
                    Id = 5,
                    FirstName = "Jacob",
                    LastName = "Hunt",
                    BirthOfYear = 1991,
                    Specialties = "C#",
                    Experience = "",
                    Url = "",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",

                    Evaluation = 1
                },
                new Trainer
                {
                    Id = 6,
                    FirstName = "Osamu",
                    LastName = "Dazai",
                    BirthOfYear = 1989,
                    Specialties = "C#",


                    Experience = "",
                    Url = "",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",

                    Evaluation = 1
                },
                new Trainer
                {
                    Id = 7,
                    FirstName = "Zachery",
                    LastName = "Salas",
                    BirthOfYear = 1983,
                    Specialties = "C#",


                    Experience = "",
                    Url = "",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",

                    Evaluation = 1
                },
                new Trainer
                {
                    Id = 8,
                    FirstName = "Matt",
                    LastName = "Haig",
                    BirthOfYear = 1982,
                    Specialties = "C#",


                    Experience = "",
                    Url = "",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",

                    Evaluation = 1
                },
                new Trainer
                {
                    Id = 9,
                    FirstName = "William",
                    LastName = "Hawkingan",
                    BirthOfYear = 1982,
                    Specialties = "C#",


                    Experience = "",
                    Url = "",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",

                    Evaluation = 1
                },
                new Trainer
                {
                    Id = 10,
                    FirstName = "Geraldine",
                    LastName = "Richmond",
                    BirthOfYear = 1990,
                    Specialties = "C#",


                    Experience = "",
                    Url = "",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",

                    Evaluation = 1
                },
                new Trainer
                {
                    Id = 11,
                    FirstName = "Steffan",
                    LastName = "Ros",
                    BirthOfYear = 1983,
                    Specialties = "C#",


                    Experience = "",
                    Url = "",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",

                    Evaluation = 1
                },
                new Trainer
                {
                    Id = 12,
                    FirstName = "Nichole",
                    LastName = "Talley",
                    BirthOfYear = 1991,
                    Specialties = "C#",


                    Experience = "",
                    Url = "",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",

                    Evaluation = 1
                },
                new Trainer
                {
                    Id = 13,
                    FirstName = "Yetta",
                    LastName = "Sheppard",
                    BirthOfYear = 1979,
                    Specialties = "C#",


                    Experience = "",
                    Url = "",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",

                    Evaluation = 1
                },
                new Trainer
                {
                    Id = 14,
                    FirstName = "Elijah",
                    LastName = "Farley",
                    BirthOfYear = 1978,
                    Specialties = "C#",


                    Experience = "",
                    Url = "",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",

                    Evaluation = 1
                },
                new Trainer
                {
                    Id = 15,
                    FirstName = "Neil",
                    LastName = "Wooten",
                    BirthOfYear = 1991,
                    Specialties = "C#",


                    Experience = "",
                    Url = "",
                    About = "Yazılım eğitimi, modern teknolojinin temelini oluşturan önemli bir süreçtir. Katılımcılara yazılım geliştirme süreçlerinde bilgi ve beceriler kazandırır.",

                    Evaluation = 1
                }
                );
        }
    }
}
