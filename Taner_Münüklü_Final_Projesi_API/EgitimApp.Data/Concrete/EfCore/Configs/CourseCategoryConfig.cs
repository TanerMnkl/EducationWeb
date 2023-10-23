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
    public class CourseCategoryConfig : IEntityTypeConfiguration<CoursesCategories>
    {
        public void Configure(EntityTypeBuilder<CoursesCategories> builder)
        {

            builder.HasKey(cc => new { cc.CourseId, cc.CategoryId });
            builder.HasData(
               new CoursesCategories { CourseId = 1, CategoryId = 1 },
               new CoursesCategories { CourseId = 2, CategoryId = 1 },
               new CoursesCategories { CourseId = 3, CategoryId = 1 },
               new CoursesCategories { CourseId = 4, CategoryId = 1 },
               new CoursesCategories { CourseId = 5, CategoryId = 1 },
               new CoursesCategories { CourseId = 6, CategoryId = 2 },
               new CoursesCategories { CourseId = 8, CategoryId = 2 },
               new CoursesCategories { CourseId = 9, CategoryId = 2 },
               new CoursesCategories { CourseId = 10, CategoryId = 3 },
               new CoursesCategories { CourseId = 11, CategoryId = 3 },
               new CoursesCategories { CourseId = 12, CategoryId = 3 },
               new CoursesCategories { CourseId = 13, CategoryId = 3 },
               new CoursesCategories { CourseId = 14, CategoryId = 4 },
               new CoursesCategories { CourseId = 15, CategoryId = 4 },
               new CoursesCategories { CourseId = 16, CategoryId = 4 },
               new CoursesCategories { CourseId = 17, CategoryId = 4 },
               new CoursesCategories { CourseId = 18, CategoryId = 5 },
               new CoursesCategories { CourseId = 19, CategoryId = 5 },
               new CoursesCategories { CourseId = 20, CategoryId = 5 },
               new CoursesCategories { CourseId = 21, CategoryId = 5 },
               new CoursesCategories { CourseId = 22, CategoryId = 5 },
               new CoursesCategories { CourseId = 23, CategoryId = 6 },
               new CoursesCategories { CourseId = 24, CategoryId = 6 },
               new CoursesCategories { CourseId = 25, CategoryId = 6 },
               new CoursesCategories { CourseId = 26, CategoryId = 6 },
               new CoursesCategories { CourseId = 27, CategoryId = 7 },
               new CoursesCategories { CourseId = 28, CategoryId = 7 },
               new CoursesCategories { CourseId = 29, CategoryId = 7 },
               new CoursesCategories { CourseId = 30, CategoryId = 7 });
        }
    }
}
