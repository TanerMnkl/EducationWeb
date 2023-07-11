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
    public class   LessonCategoryConfig :IEntityTypeConfiguration<CategoriesLessons>
    {
        public void Configure(EntityTypeBuilder<CategoriesLessons> builder)
        {
            builder.HasKey(lc => new { lc.LessonId, lc.CategoryId });
            builder.HasData(
                new CategoriesLessons { CategoryId=1,LessonId=1},
               new CategoriesLessons { CategoryId = 1, LessonId = 19 },


               new CategoriesLessons { CategoryId = 2, LessonId = 1 },
               new CategoriesLessons { CategoryId = 2, LessonId = 2 },
               new CategoriesLessons { CategoryId = 2, LessonId = 5 },
               new CategoriesLessons { CategoryId = 2, LessonId = 7 },


               new CategoriesLessons { CategoryId = 3, LessonId = 15 },
               new CategoriesLessons { CategoryId = 3, LessonId = 3 },

                new CategoriesLessons { CategoryId = 3, LessonId = 6 },


                new CategoriesLessons { CategoryId = 4, LessonId = 16 },
                new CategoriesLessons { CategoryId = 4, LessonId = 14 },

                new CategoriesLessons { CategoryId = 5, LessonId = 1 },
                new CategoriesLessons { CategoryId = 5, LessonId = 2 },
                new CategoriesLessons { CategoryId = 5, LessonId = 20 },
                new CategoriesLessons { CategoryId = 5, LessonId = 19 },
                new CategoriesLessons { CategoryId = 5, LessonId = 7 },


                new CategoriesLessons { CategoryId = 6, LessonId = 4 },
                new CategoriesLessons { CategoryId = 6, LessonId = 8 },
                new CategoriesLessons { CategoryId = 6, LessonId = 13 },

                new CategoriesLessons { CategoryId =7 , LessonId = 17 },
                new CategoriesLessons { CategoryId = 7, LessonId = 18 },


                new CategoriesLessons { CategoryId = 8, LessonId = 7 },
                new CategoriesLessons { CategoryId = 8, LessonId = 5 },
                new CategoriesLessons { CategoryId = 8, LessonId = 9 },


                new CategoriesLessons { CategoryId = 9, LessonId = 9 },
                 new CategoriesLessons { CategoryId = 9, LessonId = 10 },
                  new CategoriesLessons { CategoryId = 9, LessonId =11 },
                   new CategoriesLessons { CategoryId = 9, LessonId = 12 }



                );
        }
    }
}
