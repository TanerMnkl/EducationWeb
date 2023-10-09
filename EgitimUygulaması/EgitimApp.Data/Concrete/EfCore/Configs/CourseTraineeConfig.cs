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
    public class CourseTraineeConfig : IEntityTypeConfiguration<CoursesTrainees>
    {
        public void Configure(EntityTypeBuilder<CoursesTrainees> builder)
        {
            builder.HasKey(ct => new { ct.CourseId, ct.TraineeId });
            builder.HasData(
                new CoursesTrainees { CourseId = 1, TraineeId = 1 },
                new CoursesTrainees { CourseId = 2, TraineeId = 1 },
                new CoursesTrainees { CourseId = 3, TraineeId = 1 },
                new CoursesTrainees { CourseId = 4, TraineeId = 1 },
                new CoursesTrainees { CourseId = 5, TraineeId = 1 },
                new CoursesTrainees { CourseId = 6, TraineeId = 2 },
                new CoursesTrainees { CourseId = 8, TraineeId = 2 },
                new CoursesTrainees { CourseId = 9, TraineeId = 2 },
                new CoursesTrainees { CourseId = 10, TraineeId = 3 },
                new CoursesTrainees { CourseId = 11, TraineeId = 3 },
                new CoursesTrainees { CourseId = 12, TraineeId = 3 },
                new CoursesTrainees { CourseId = 13, TraineeId = 3 },
                new CoursesTrainees { CourseId = 14, TraineeId = 4 },
                new CoursesTrainees { CourseId = 15, TraineeId = 4 },
                new CoursesTrainees { CourseId = 16, TraineeId = 4 },
                new CoursesTrainees { CourseId = 17, TraineeId = 4 },
                new CoursesTrainees { CourseId = 18, TraineeId = 5 },
                new CoursesTrainees { CourseId = 19, TraineeId = 5 },
                new CoursesTrainees { CourseId = 20, TraineeId = 5 },
                new CoursesTrainees { CourseId = 21, TraineeId = 5 },
                new CoursesTrainees { CourseId = 22, TraineeId = 5 },
                new CoursesTrainees { CourseId = 23, TraineeId = 6 },
                new CoursesTrainees { CourseId = 24, TraineeId = 6 },
                new CoursesTrainees { CourseId = 25, TraineeId = 6 },
                new CoursesTrainees { CourseId = 26, TraineeId = 6 },
                new CoursesTrainees { CourseId = 27, TraineeId = 7 },
                new CoursesTrainees { CourseId = 28, TraineeId = 7 },
                new CoursesTrainees { CourseId = 29, TraineeId = 7 },
                new CoursesTrainees { CourseId = 30, TraineeId = 8 });
        }
    }
}
