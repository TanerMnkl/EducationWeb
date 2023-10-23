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
    public class SettingsConfig : IEntityTypeConfiguration<Settings>
    {
        public void Configure(EntityTypeBuilder<Settings> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedDate).IsRequired();

            builder.Property(x => x.ModifiedDate).IsRequired();

            builder.Property(x => x.IsActive).IsRequired();

            builder.Property(x => x.IsDeleted).IsRequired();

            builder.Property(x => x.CompanyName).IsRequired();

            builder.Property(x => x.Adress).IsRequired();

            builder.Property(x => x.About).IsRequired();

            builder.Property(x => x.Contact).IsRequired();

            builder.Property(x => x.QuestionAsked).IsRequired();
        }
    }
}
