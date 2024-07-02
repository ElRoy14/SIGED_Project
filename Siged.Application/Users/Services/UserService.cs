using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Siged.Application.Authentication.Exceptions;
using Siged.Application.Users.DTOs;
using Siged.Application.Users.Exceptions;
using Siged.Application.Users.Interfaces;
using Siged.Application.Users.Validators;
using Siged.Domain;
using Siged.Domain.Enums;
using Siged.Domain.Interfaces;

namespace Siged.Application.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<UserInfo> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<UserInfo> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<GetUser>> GetAllUserAsync()
        {
            try
            {
                var userQuery = await _userRepository.VerifyDataExistenceAsync();
                var listUser = userQuery
                    .Include(rol => rol.Rol)
                    .Include(rol => rol.JobTitle)
                    .Include(rol => rol.Department).ToList();

                return _mapper.Map<List<GetUser>>(listUser);
            }
            catch
            {
                throw new GetUsersFailedException();
            }

        }

        public async Task<GetUser> Register(CreateUser model)
        {
            try
            {
                var createUserValidator = new CreateUserValidator();
                var validationResult = createUserValidator.Validate(model);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                    throw new TaskCanceledException($"{string.Join(", ", errors)}");
                }

                var userCreated = await _userRepository.CreateAsync(_mapper.Map<UserInfo>(model));

                var userException = userCreated.UserId == (int)UserCreationOption.DoNotCreate ? throw new UserNotCreatedException() : userCreated;

                var query = await _userRepository.VerifyDataExistenceAsync(u => u.UserId == userCreated.UserId);
                userCreated = query
                    .Include(rol => rol.Rol)
                    .Include(rol => rol.JobTitle)
                    .Include(rol => rol.Department).First();

                return _mapper.Map<GetUser>(userCreated);

            }
            catch
            {
                throw;
            }

        }
        public async Task<GetUser> GetUserByIdAsync(int id)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(id);
                if (user == null)
                    throw new UserNotFoundException(); // Implementa esta excepción según tu lógica de manejo de errores

                return _mapper.Map<GetUser>(user);
            }
            catch
            {
                throw;
            }
        }

       


        public async Task<bool> UpdateAsync(UpdateUser model)
        {
            try
            {
                var validator = new UpdateUserValidator();
                var validationResult = await validator.ValidateAsync(model);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                    throw new TaskCanceledException(string.Join(", ", errors));
                }

                var userModel = _mapper.Map<UserInfo>(model);

                var userFound = await _userRepository.GetEverythingAsync(u => u.UserId == userModel.UserId);

                var userToUpdate = userFound ?? throw new UserNotFoundException();

                userToUpdate.IdentificationCard = userModel.IdentificationCard;
                userToUpdate.FullName = userModel.FullName;
                userToUpdate.PhoneNumber = userModel.PhoneNumber;
                userToUpdate.Email = userModel.Email;
                userToUpdate.UserPassword = userModel.UserPassword;
                userToUpdate.RolId = userModel.RolId;
                userToUpdate.JobTitleId = userModel.JobTitleId;
                userToUpdate.DepartmentId = userModel.DepartmentId;
                userToUpdate.IsActive = userModel.IsActive;

                bool response = await _userRepository.UpdateAsync(userToUpdate);

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
                var userFound = await _userRepository.GetEverythingAsync(u => u.UserId == id);

                var userDelete = userFound ?? throw new UserNotFoundException();

                bool response = await _userRepository.DeleteAsync(userFound);

                var isDeleteSuccessful = response ? response : throw new DeleteUserFailedException();

                return response;
            }
            catch
            {
                throw new DeleteUserErrorFailedException();
            }

        }

    }



}