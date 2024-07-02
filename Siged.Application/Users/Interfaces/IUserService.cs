﻿using Siged.Application.Users.DTOs;

namespace Siged.Application.Users.Interfaces
{
    public interface IUserService
    {
        Task<List<GetUser>> GetAllUserAsync();
        Task<GetUser> Register(CreateUser model);
        Task<bool> UpdateAsync(UpdateUser model);
        Task<bool> DeleteAsync(int id);

        Task<GetUser> GetUserByIdAsync(int id);
    }

}