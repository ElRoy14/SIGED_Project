using AutoMapper;
using Siged.Application.PerformanceEvaluations.DTOs;
using Siged.Application.PerformanceEvaluations.Interfaces;
using Siged.Application.PerformanceEvaluations.Exceptions;
using Siged.Domain;
using Siged.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Siged.Application.Users.DTOs;
using Siged.Application.Users.Exceptions;
using Siged.Application.Users.Validators;
using Siged.Domain.Enums;
using Siged.Application.PerformanceEvaluations.Validators;
using FluentValidation;
using Siged.Application.Authentication.Exceptions;
using Siged.Application.Customers.DTOs;

namespace Siged.Application.PerformanceEvaluations.Services
{
    public class PerformanceEvalutionService : IPerformanceEvaluationService
    {
        private readonly IGenericRepository<PerformanceEvaluation> _performanceRepository;
        private readonly IMapper _mapper;

        public PerformanceEvalutionService(
            IGenericRepository<PerformanceEvaluation> performanceRepository, 
            IMapper mapper)
        {
            _performanceRepository = performanceRepository;
            _mapper = mapper;
        }

        

        public async Task<List<GetPerformanceEvaluation>> GetAllPerformanceAsycn()
        {
            try
            {
                var performance = await _performanceRepository.VerifyDataExistenceAsync();
                var listPerformance = performance
                    .Include(p => p.Evaluator)
                        .ThenInclude(e => e.User)
                    .Include(p => p.Goal)
                    .Include(p => p.User).ToList();

                return _mapper.Map<List<GetPerformanceEvaluation>>(performance);

            }
            catch
            {
                throw new GetPerformanceFailedException(); 
            }

        }

        public async Task<GetPerformanceEvaluation> Register(CreatePerformanceEvaluation model)
        {
            try
            {
                var createUserValidator = new CreatePerformanceValidator();
                var validationResult = createUserValidator.Validate(model);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                    throw new TaskCanceledException($"{string.Join(", ", errors)}");
                }

                var userCreated = await _performanceRepository.CreateAsync(_mapper.Map<PerformanceEvaluation>(model));

                var userException = userCreated.PerformanceEvaluationId == (int)DataCreationOption.DoNotCreate ? throw new UserNotCreatedException() : userCreated;

                var query = await _performanceRepository.VerifyDataExistenceAsync(u => u.PerformanceEvaluationId == userCreated.PerformanceEvaluationId);
                userCreated = query
                    .Include(rol => rol.Evaluator)
                    .Include(rol => rol.Goal)
                    .Include(rol => rol.User).First();

                return _mapper.Map<GetPerformanceEvaluation>(userCreated);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(UpdatePerformanceEvaluation model)
        {
            try
            {
                var validator = new UpdatePerformanceValidator();
                var validationResult = await validator.ValidateAsync(model);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                    throw new TaskCanceledException(string.Join(", ", errors));
                }

                var userModel = _mapper.Map<PerformanceEvaluation>(model);

                var userFound = await _performanceRepository.GetEverythingAsync(u => u.PerformanceEvaluationId == userModel.PerformanceEvaluationId);

                var userToUpdate = userFound ?? throw new UserNotFoundException();

                userToUpdate.EvaluatorId = userModel.EvaluatorId;
                userToUpdate.GoalId = userModel.GoalId;
                userToUpdate.UserId = userModel.UserId;
                userToUpdate.Rating = userModel.Rating;

                bool response = await _performanceRepository.UpdateAsync(userToUpdate);

                bool isUpdateSuccessful = !response ? throw new UpdateUserFailedException() : response;

                return response;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var userFound = await _performanceRepository.GetEverythingAsync(u => u.PerformanceEvaluationId == id);

                var userDelete = userFound ?? throw new UserNotFoundException();

                bool response = await _performanceRepository.DeleteAsync(userFound);

                var isDeleteSuccessful = response ? response : throw new DeleteUserFailedException();

                return response;
            }
            catch
            {
                throw new DeleteUserErrorFailedException();
            }
        }

        public async Task<GetPerformanceEvaluation> GetPerformanceById(int id)
        {
           

                try
                {
                    var user = await _performanceRepository.GetByIdAsync(id);
                    if (user == null)
                        throw new UserNotFoundException(); // Implementa esta excepción según tu lógica de manejo de errores

                    return _mapper.Map<GetPerformanceEvaluation>(user);
                }
                catch
                {
                    throw;
                }
            
        }
    }



}
