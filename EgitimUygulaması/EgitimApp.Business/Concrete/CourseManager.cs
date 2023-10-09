﻿using AutoMapper;
using EgitimApp.Business.Abstract;
using EgitimApp.Data.Abstract;
using EgitimApp.Entity.Concrete;
using EgitimApp.Shared.DTOs;
using EgitimApp.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Business.Concrete
{
    public class CourseManager : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        
        private readonly ITrainerRepository _trainerRepository;
        
        private readonly IMapper _mapper;



        public CourseManager(ICourseRepository courseRepository, ITrainerRepository trainerRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            
            _trainerRepository = trainerRepository;
            
            _mapper = mapper;
        }

        public async Task CheckCoursesCategories()
        {
            await _courseRepository.CheckCoursesCategories();
        }

        public async Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto)
        {
            var newCourse=_mapper.Map<Course>(courseCreateDto);
            newCourse.CreatedDate=DateTime.Now;
            newCourse.Trainer=await _trainerRepository.GetByIdAsync(newCourse.TrainerId);   
            await _courseRepository.CreateAsync(newCourse);

            return Response<CourseDto>.Success(_mapper.Map<CourseDto>(newCourse),201);
        }

        public async Task CreateCourseAsync(Course course, List<int> SelectedCategoryIds)
        {
            await _courseRepository.CreateCourseAsync(course, SelectedCategoryIds);
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var deletedCourse= await _courseRepository.GetByIdAsync(id);
            if (deletedCourse==null)
            {
                return Response<NoContent>.Fail("Böyle bir kurs yok", 401);

            }
            _courseRepository.Delete(deletedCourse);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<CourseDto>>> GetAllActiveCoursesAsync(string categoryUrl = null, string traineeUrl = null, string trainerUrl = null)
        {
            var courseList=await _courseRepository.GetAllActiveCoursesAsync(categoryUrl, traineeUrl, trainerUrl);
            if (courseList.Any())
            {
                var courseDtoList = _mapper.Map<List<CourseDto>>(courseList);
                return Response<List<CourseDto>>.Success(courseDtoList, 200);
            }
            return Response<List<CourseDto>>.Fail("Kayıtlı Kurs Bulunamadı", 401);
        }

        public async Task<Response<List<CourseDto>>> GetAllAsync()
        {
            var courseList = await _courseRepository.GetAllAsync();
            if (courseList.Any())
            {
                foreach (var course in courseList)
                {
                    course.Trainer = await _trainerRepository.GetByIdAsync(course.TrainerId);
                    
                }

                var courseDtoList = _mapper.Map<List<CourseDto>>(courseList);
                return Response<List<CourseDto>>.Success(courseDtoList, 200);
            }
            return Response<List<CourseDto>>.Fail("Kayıtlı kurs bulunamadı", 401);
        }

        public async Task<Response<List<CourseDto>>> GetAllCoursesWithTrainerAndTrainee(bool isDeleted)
        {
            var courseList=await _courseRepository.GetCoursesWitFullDataAsync(isDeleted);
            if (courseList.Any())
            {
                var courseDtoList = _mapper.Map<List<CourseDto>>(courseList);
                return Response<List<CourseDto>>.Success(courseDtoList, 200);
            }
            return Response<List<CourseDto>>.Fail("Kayıtlı Kurs Bulunamadı", 401);
        }

        public async Task<Response<List<CourseDto>>> GetCoursesByCategoryAsync(int categoryId)
        {
            var courseList = await _courseRepository.GetCoursesByCategoryAsync(categoryId);
            if (courseList.Any())
            {
                var courseDtoList = _mapper.Map<List<CourseDto>>(courseList);
                return Response<List<CourseDto>>.Success(courseDtoList, 200);
            }
            return Response<List<CourseDto>>.Fail("Kayıtlı Kurs Bulunamadı", 401);
        }

        public async Task<Response<CourseDto>> GetByIdAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course != null)
            {
                course.Trainer = await _trainerRepository.GetByIdAsync(course.TrainerId);
                

                var courseDto = _mapper.Map<CourseDto>(course);
                return Response<CourseDto>.Success(courseDto, 200);
            }
            return Response<CourseDto>.Fail("kurs bulunamadı", 401);
        }

        public async Task<Response<CourseDto>> GetCourseByUrlAsync(string courseUrl)
        {
            var course = await _courseRepository.GetCourseByUrlAsync(courseUrl);
            if (course != null)
            {
                var courseDto = _mapper.Map<CourseDto>(course);
                return Response<CourseDto>.Success(courseDto, 200);
            }
            return Response<CourseDto>.Fail("Böyle bir kurs bulunamadı", 401);
        }

        public async Task<Response<CourseDto>> GetCoursesByIdAsync(int id)
        {
            var course = await _courseRepository.GetCoursesByIdAsync(id);
            if (course!=null)
            {
                var courseDto=_mapper.Map<CourseDto>(course);
                return Response<CourseDto>.Success(courseDto, 200);

                
            }
            return Response<CourseDto>.Fail("Kurs Bulunamadı", 401);
        }

        public async Task<Response<List<CourseDto>>> GetCoursesWithFullDataAsync(bool? isActive = null)
        {
            var courseList= await _courseRepository.GetCoursesWitFullDataAsync(isActive);
            if (courseList.Any())
            {
                var courseDtoList = _mapper.Map<List<CourseDto>>(courseList);
                return Response<List<CourseDto>>.Success(courseDtoList, 200);

            }
            return Response<List<CourseDto>>.Fail("kayıtlı bir kurs bulunamadı", 401);
        }

        public async Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto)
        {
            var isThere = await _courseRepository.AnyAsync(courseUpdateDto.Id);
            if (isThere) 
            {
                var course= _mapper.Map<Course>(courseUpdateDto);
                course.ModifiedDate=DateTime.Now;
                _courseRepository.Update(course);
                return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("Böyle bir kurs bulunamadı", 401);
        }

        public void UpdateCourse(Course course)
        {
            _courseRepository.UpdateCourse(course);
        }

        public async Task UpdateTrainerOfCourses()
        {
            await _courseRepository.UpdateTrainerOfCourses();
                
        }
    }
}
