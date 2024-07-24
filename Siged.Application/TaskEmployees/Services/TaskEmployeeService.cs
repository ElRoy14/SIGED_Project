using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Siged.Application.Authentication.Exceptions;
using Siged.Application.TaskEmployees.DTOs;
using Siged.Application.TaskEmployees.Exceptions;
using Siged.Application.TaskEmployees.Interfaces;
using Siged.Application.TaskEmployees.Validators;
using Siged.Application.Users.Exceptions;
using Siged.Application.Users.Validators;
using Siged.Domain;
using Siged.Domain.Enums;
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
                                .Include(status => status.User)
                                .Include(user => user.TaskStatus).ToList();

                return _mapper.Map<List<GetTask>>(listTasks);
            }
            catch 
            {
                throw new GetTaskFailedException();
            }
        }

        private async Task<List<GetTask>> GetTaslByStatusAsync(TaskStatusEmployeeOption status)
        {
            try
            {
                var invoiceQuery = await _taskRepository
                    .VerifyDataExistenceAsync(task => task.TaskStatusId == (int)status);

                var invoicesWithInclude = invoiceQuery
                    .Include(invoice => invoice.User)
                    .Include(invoice => invoice.TaskStatus)
                    .ToList();

                return _mapper.Map<List<GetTask>>(invoicesWithInclude);
            }
            catch
            {
                throw new GetTaskFailedException();
            }

        }

        public async Task<List<GetTask>> GetAllPendingTaskAsync()
        {
            return await GetTaslByStatusAsync(TaskStatusEmployeeOption.Pending);
        }

        public async Task<List<GetTask>> GetAllTaskListDoneAsync()
        {
            return await GetTaslByStatusAsync(TaskStatusEmployeeOption.Done);
        }


        private async Task<List<GetTask>> GetTaskByUserAsync(int userId, TaskStatusEmployeeOption stateId)
        {
            try
            {
                var assignedInvoices = await _taskRepository
                    .VerifyDataExistenceAsync(invoice => invoice.UserId == userId && invoice.TaskStatusId == (int)stateId);

                string noInvoicesFound = assignedInvoices == null || !assignedInvoices.Any() ? throw new GetTaskFailedByUserException() : null;

                var invoicesWithInclude = assignedInvoices
                    .Include(user => user.User)
                    .Include(user => user.TaskStatus);

                var invoiceList = await invoicesWithInclude.ToListAsync();

                return _mapper.Map<List<GetTask>>(invoiceList);
            }
            catch
            {
                throw;
            }

        }

        public async Task<List<GetTask>> GetPendingTaskByEmployee(int userId)
        {
            return await GetTaskByUserAsync(userId, TaskStatusEmployeeOption.Pending);
        }

        public async Task<List<GetTask>> GetTaskDoneByEmployee(int userId)
        {
            return await GetTaskByUserAsync(userId, TaskStatusEmployeeOption.Done);
        }

        public async Task<GetTask> GetTaskById(int id)
        {
            try
            {
                var task = await _taskRepository
                    .GetByIdAsync(id);

                return _mapper.Map<GetTask>(task);
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
                var createUserValidator = new CreateTaskValidators();
                var validationResult = createUserValidator.Validate(model);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                    throw new TaskCanceledException($"{string.Join(", ", errors)}");
                }

                var stateInfo = _mapper.Map<TasksEmployee>(model);

                stateInfo.TaskStatusId = (int)TaskStatusEmployeeOption.Pending;

                var taskCreated = await _taskRepository.CreateAsync(stateInfo);

                var taskException = taskCreated.TaskId == (int)DataCreationOption.DoNotCreate ? throw new TaskNotCreatedException() : taskCreated;
                
                var query = await _taskRepository.VerifyDataExistenceAsync(t => t.TaskId == taskCreated.TaskId );
                
                taskCreated = query
                                .Include(taskStatus => taskStatus.User)
                                .Include(user => user.TaskStatus).First();

                return _mapper.Map<GetTask>(taskCreated);
                                
            }
            catch
            {
                throw new TaskNotCreatedException();
            }

        }

        public async Task<bool> UpdateAsync(UpdateTask model)
        {
            try
            {
                var validator = new UpdateTaskValidators();
                var validationResult = await validator.ValidateAsync(model);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                    throw new TaskCanceledException(string.Join(", ", errors));
                }

                var taskModel = _mapper.Map<TasksEmployee>(model);

                var taskFound = await _taskRepository.GetEverythingAsync(u => u.TaskId == taskModel.TaskId);

                var taskToUpdate = taskFound ?? throw new TaskNotFoundException();

                taskToUpdate.TaskId = taskModel.TaskId;
                taskToUpdate.NameTask = taskModel.NameTask;
                taskToUpdate.DueDate = taskModel.DueDate;
                taskToUpdate.UserId = taskModel.UserId;

                bool response = await _taskRepository.UpdateAsync(taskToUpdate);

                bool isUpdateSuccessful = !response ? throw new TaskUpdateFailedException() : response;

                    return response;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateStateAsync(UpdateStateTask model)
        {
            try
            {
                var validator = new UpdateStateValidator();
                var validationResult = await validator.ValidateAsync(model);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                    throw new TaskCanceledException(string.Join(", ", errors));
                }

                var invoiceModel = _mapper.Map<TasksEmployee>(model);

                var invoiceFound = await _taskRepository.GetEverythingAsync(u => u.TaskId == invoiceModel.TaskId);

                var invoiceToUpdate = invoiceFound ?? throw new TaskNotFoundException();

                invoiceToUpdate.TaskStatusId = invoiceModel.TaskStatusId;

                bool response = await _taskRepository.UpdateAsync(invoiceFound);

                bool isUpdateSuccessful = !response ? throw new TaskUpdateFailedException() : response;

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
                var taskFound = await _taskRepository.GetEverythingAsync(u => u.TaskId == id);

                var taskDelete = taskFound ?? throw new TaskNotFoundException();

                bool response = await _taskRepository.DeleteAsync(taskFound);

                var isDeleteSuccessful = response ? response : throw new DeleteTaskFailedException();

                    return response;
            }
            catch
            {
                throw new TaskNotFoundException();
            }
        }

    }
}
