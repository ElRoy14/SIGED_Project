using AutoMapper;
using Siged.Application.TaskStatusEmployees.DTOs;
using Siged.Application.TaskStatusEmployees.Interfaces;
using Siged.Application.TaskStatusEmployees.Exceptions;
using Siged.Domain;
using Siged.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.TaskStatusEmployees.Services
{
    public class TaskStatusEmployeeService : ITaskStatusEmployeeService
    {
        private readonly IGenericRepository<TaskStatusEmployee> _taskStatusEmployeerepository;
        private readonly IMapper _mapper;

        public TaskStatusEmployeeService(
            IGenericRepository<TaskStatusEmployee> taskStatusEmployeerepository, 
            IMapper mapper
            )
        {
            _taskStatusEmployeerepository = taskStatusEmployeerepository;
            _mapper = mapper;
        }

        public async Task<List<GetTaskStatusEmployee>> GetAllTaskStatusEmployeeAsync()
        {
            try
            {
                var task = await _taskStatusEmployeerepository.VerifyDataExistenceAsync();
                return _mapper.Map<List<GetTaskStatusEmployee>>(task.ToList());
            }
            catch
            {
                throw new GetTaskStatusEmployeeFailedException();
            }

        }

    }

}
