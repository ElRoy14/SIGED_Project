using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Siged.Application.Authentication.Exceptions;
using Siged.Application.TaskEmployees.DTOs;
using Siged.Application.TaskEmployees.Exceptions;
using Siged.Application.TaskEmployees.Interfaces;
using Siged.Application.Users.Exceptions;
using Siged.Domain;
using Siged.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siged.Application.TaskEmployees.Services
{
    public class TaskEmployeeService : ITaskEmployeeService
    {
        private readonly IGenericRepository<TasksEmployee> _taskRepository;
        private readonly IMapper _mapper;

        public TaskEmployeeService(IGenericRepository<TasksEmployee> taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<List<GetTask>> GetAllTaskAsync()
        {
            try
            {
                var taskQuery = await _taskRepository.VerifyDataExistenceAsync();
                var listTasks = taskQuery
                                .Include(status => status.TaskStatus)
                                .Include(user => user.User).ToList();
                return _mapper.Map<List<GetTask>>(listTasks);
            }
            catch 
            {
                throw new GetTaskFailedException();
            }
        }

        public async Task<GetTask> GetTaskById(int id)
        {
            try
            {
                var task = await _taskRepository.GetByIdAsync(id);
                return _mapper.Map<GetTask>(task);
            }
            catch
            {
                throw new GetTaskFailedException();
            }
        }

        public async Task<List<GetTask>> GetTaskByNameAsync(string name)
        {
            try
            {
                var taskQuery = await _taskRepository.VerifyDataExistenceAsync(c => c.NameTask == name);
                var listTasks = taskQuery
                                .Include(status => status.TaskStatus)
                                .Include(user => user.User).ToList();
                return _mapper.Map<List<GetTask>>(listTasks);
            }
            catch
            {
                throw new GetTaskFailedException();
            }
        }

        public async Task<GetTask> CreateTask(CreateTask model)
        {
            try
            {
                var taskCreated = await _taskRepository.CreateAsync(_mapper.Map<TasksEmployee>(model));
                var query = await _taskRepository.VerifyDataExistenceAsync(t => t.TaskId == taskCreated.TaskId );
                taskCreated = query
                                .Include(taskStatus => taskStatus.TaskStatus)
                                .Include(user => user.User).First();
                return _mapper.Map<GetTask>(taskCreated);
                                
            }
            catch
            {
                throw new TaskNotCreatedException();
            }
        }

        public async Task<bool> UpdateAsync(UpdateTask model)
        {
            var taskModel = _mapper.Map<TasksEmployee>(model);

            var taskFound = await _taskRepository.GetEverythingAsync(u => u.TaskId == taskModel.TaskId);

            var taskToUpdate = taskFound ?? throw new TaskNotFoundException();

            taskToUpdate.TaskId = taskModel.TaskId;
            taskToUpdate.TaskStatusId = taskModel.TaskStatusId;
            taskToUpdate.NameTask = taskModel.NameTask;
            taskToUpdate.StartDate = taskModel.StartDate;
            taskToUpdate.DueDate = taskModel.DueDate;

            bool response = await _taskRepository.UpdateAsync(taskToUpdate);

            bool isUpdateSuccessful = !response ? throw new TaskUpdateFailedException() : response;

            return response;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var taskFound = await _taskRepository.GetEverythingAsync(u => u.TaskId == id);

            var taskDelete = taskFound ?? throw new TaskNotFoundException();

            bool response = await _taskRepository.DeleteAsync(taskFound);

            var isDeleteSuccessful = response ? response : throw new DeleteTaskFailedException();

            return response;
        }

        
    }
}
