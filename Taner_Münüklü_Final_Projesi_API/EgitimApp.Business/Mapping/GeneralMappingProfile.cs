using AutoMapper;
using EgitimApp.Entity.Concrete;
using EgitimApp.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Business.Mapping
{
    public class GeneralMappingProfile:Profile
    {
      public GeneralMappingProfile() 
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category,CategoryCreateDto>().ReverseMap();
            CreateMap<Category,CategoryUpdateDto>().ReverseMap(); 

            CreateMap<Course,CourseDto>().ForMember(c=>c.Categories,opt=>opt.MapFrom(c=>c.CoursesCategories.Select(c=>c.Category))).ReverseMap();
            CreateMap<Course, CourseDto>().ForMember(c => c.Trainee, opt => opt.MapFrom(c => c.CoursesTrainees.Select(c => c.Trainee))).ReverseMap();
            CreateMap<Course,CourseCreateDto>().ReverseMap();
            CreateMap<Course,CourseUpdateDto>().ReverseMap();

            CreateMap<Settings,SettingsDto>().ReverseMap();
            CreateMap<Settings,SettingsUpdateDto>().ReverseMap(); 
            CreateMap<Settings,SettingsCreateDto>().ReverseMap();


            CreateMap<Trainee,TraineeDto>().ReverseMap();
            CreateMap<Trainee,TraineeCreateDto>().ReverseMap();
            CreateMap<Trainee,TraineeUpdateDto>().ReverseMap();


            CreateMap<Trainer,TrainerDto>().ReverseMap();
            CreateMap<Trainer, TrainerCreateDto>().ReverseMap();
            CreateMap<Trainer,TrainerUpdateDto>().ReverseMap();
        
        
        }
    }
}
