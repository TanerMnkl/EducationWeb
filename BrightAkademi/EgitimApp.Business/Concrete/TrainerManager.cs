using AutoMapper;
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
    public class TrainerManager : ITrainerService
    {
        private readonly ITrainerRepository _trainerRepository;
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;


        public TrainerManager(ITrainerRepository trainerRepository, IMapper mapper, ICourseRepository courseRepository)
        {
            _trainerRepository = trainerRepository;
            _mapper = mapper;
            _courseRepository = courseRepository;
        }

        public async Task<Response<TrainerDto>> CreateAsync(TrainerCreateDto trainerCreateDto)
        {
            var newTrainer=_mapper.Map<Trainer>(trainerCreateDto); 
            newTrainer.CreatedDate=DateTime.Now;
            await _trainerRepository.CreateAsync(newTrainer);
            var trainerDto= _mapper.Map<TrainerDto>(newTrainer);
            return Response<TrainerDto>.Success(trainerDto, 201);
        }

        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var deletedTrainer = await _trainerRepository.GetByIdAsync(id);
            if (deletedTrainer == null)
            {
                return Response<NoContent>.Fail("Böyle bir trainer yoktur", 404);
            }
            _trainerRepository.Delete(deletedTrainer);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<List<TrainerDto>>> GetAllAsync()
        {
            var trainerList= await _trainerRepository.GetAllTrainersAsync(false);
            if (!trainerList.Any())
            {
                return Response<List<TrainerDto>>.Fail("böyle bir trainer yoktur", 404);
                
            }
            var trainerListDto= _mapper.Map<List<TrainerDto>>(trainerList);
            return Response<List<TrainerDto>>.Success(trainerListDto, 201);
        }

        public async Task<Response<TrainerDto>> GetByIdAsync(int? id)
        {
            var trainer = await _trainerRepository.GetByIdAsync(id);
            if (trainer !=null )
            {
                var trainerDto= _mapper.Map<TrainerDto>(trainer);  
                return Response<TrainerDto>.Success(trainerDto, 200);
                
            }
            return Response<TrainerDto>.Fail("böyle bir trainer bulunamadı", 401);
        }

        public Task<Response<NoContent>> UpdateAsync(TrainerUpdateDto trainerUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
