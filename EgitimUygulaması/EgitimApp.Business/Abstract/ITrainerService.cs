﻿using EgitimApp.Entity.Concrete;
using EgitimApp.Shared.DTOs;
using EgitimApp.Shared.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimApp.Business.Abstract
{
    public interface ITrainerService
    {
        #region Generic
        Task<Response<TrainerDto>> GetByIdAsync(int? id);
        Task<Response<List<TrainerDto>>> GetAllAsync();
        Task<Response<TrainerDto>> CreateAsync(TrainerCreateDto trainerCreateDto);
        Task<Response<NoContent>> UpdateAsync(TrainerUpdateDto trainerUpdateDto);
        Task<Response<NoContent>> DeleteAsync(int id);
        #endregion
    }
}
