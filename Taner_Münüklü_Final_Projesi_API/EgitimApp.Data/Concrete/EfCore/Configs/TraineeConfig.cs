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
    public class TraineeConfig : IEntityTypeConfiguration<Trainee>
    {
        public void Configure(EntityTypeBuilder<Trainee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedDate).IsRequired();

            builder.Property(x => x.ModifiedDate).IsRequired();

            builder.Property(x => x.IsActive).IsRequired();

            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.FirstName).IsRequired();

            builder.Property(x => x.LastName).IsRequired();

            builder.Property(x => x.Education).IsRequired();

            builder.Property(x => x.Url).IsRequired();



            builder.HasData(
               new Trainee
               {
                   Id = 1,
                   FirstName = "Taner",
                   LastName = "Münüklü",
                   Education = ".NET (.NET Core, MVC, Web API)",
                   Url = "taner-munuklu",

               },
               new Trainee
               {
                   Id = 2,
                   FirstName = "Serkan",
                   LastName = "Selek",
                   Education = "Java (Spring, Java SE, Java EE)",
                   Url = "serkan-selek",

               },
               new Trainee
               {
                   Id = 3,
                   FirstName = "Furkan",
                   LastName = "Yüksel",
                   Education = "Python",
                   Url = "furkan-yuksel",

               },
               new Trainee
               {
                   Id = 4,
                   FirstName = "Selimcan",
                   LastName = "Engin",
                   Education = "JavaScript",
                   Url = "selo-engin",

               },
               new Trainee
               {
                   Id = 5,
                   FirstName = "Emre",
                   LastName = "Candar",
                   Education = "C/C++",
                   Url = "emre-candar",

               },
               new Trainee
               {
                   Id = 6,
                   FirstName = "Atahan",
                   LastName = "Akıncı",
                   Education = "iOS & Android",
                   Url = "atahan-akıncı",

               },
               new Trainee
               {
                   Id = 7,
                   FirstName = "Alper",
                   LastName = "Karateke",
                   Education = "Node.js",
                   Url = "alper-karateke",

               },
               new Trainee
               {
                   Id = 8,
                   FirstName = "Ali",
                   LastName = "Münüklü",
                   Education = "React",
                   Url = "ali-munuklu",

               });
        }
    }
}
