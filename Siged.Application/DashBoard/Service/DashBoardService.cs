using Siged.Application.DashBoard.Interface;
using Siged.Domain.Interfaces;
using Siged.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Siged.Application.Users.DTOs;
using Siged.Application.Users.Exceptions;
using Siged.Application.TaskEmployees.Exceptions;
using Siged.Application.Customers.DTOs;
using Siged.Application.Customers.Exceptions;
using Siged.Application.Suppliers.Exceptions;
using Siged.Application.TaskEmployees.DTOs;
using AutoMapper;
using Siged.Application.Suppliers.DTOs;

namespace Siged.Application.DashBoard.Service
{
    public class DashBoardService : IDashBoardService
    {
        private readonly IGenericRepository<TasksEmployee> _taskRepository;
        private readonly IGenericRepository<UserInfo> _userRepository;
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IGenericRepository<Supplier> _supplierRepository;
        private readonly IGenericRepository<ServicePaymentInvoice> _paymentRepository;
        private readonly IMapper _mapper;

        public DashBoardService(IGenericRepository<TasksEmployee> taskRepository, IGenericRepository<UserInfo> userRepository, IGenericRepository<Customer> customerRepository, IGenericRepository<Supplier> supplierRepository, IGenericRepository<ServicePaymentInvoice> paymentRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _customerRepository = customerRepository;
            _supplierRepository = supplierRepository;
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<int> GetTotalTasksAsync()
        {
            try
            {
                var taskQuery = await _taskRepository.VerifyDataExistenceAsync();
                return taskQuery.Count();
            }
            catch
            {
                throw new GetTaskFailedException();
            };
        }

        public async Task<int> GetPendingTasksAsync()
        {
            try
            {
                var taskQuery = await _taskRepository.VerifyDataExistenceAsync();
                var listTasks = taskQuery
                                .Include(status => status.User)
                                .Include(user => user.TaskStatus).ToList();

                int pendingCount = _mapper.Map<List<GetTask>>(listTasks).Count(c => c.TaskStatusDescription == "Pendiente");

                return pendingCount;
            }
            catch
            {
                throw new GetTaskFailedException();
            };
        }

        public async Task<int> GetDoneTasksAsync()
        {
            try
            {
                var taskQuery = await _taskRepository.VerifyDataExistenceAsync();
                var listTasks = taskQuery
                                .Include(status => status.User)
                                .Include(user => user.TaskStatus).ToList();

                int doneCount = _mapper.Map<List<GetTask>>(listTasks).Count(c => c.TaskStatusDescription == "Hecha");

                return doneCount;
            }
            catch
            {
                throw new GetTaskFailedException();
            };
        }

        public async Task<int> GetTotalUsersAsync()
        {
            try
            {
                var userQuery = await _userRepository.VerifyDataExistenceAsync();
                return userQuery.Count();
            }
            catch
            {
                throw new GetUsersFailedException();
            }
        }

        public async Task<int> GetEmployeeUsersAsync()
        {
            try
            {
                var userQuery = await _userRepository.VerifyDataExistenceAsync();
                var listUser = userQuery
                    .Include(rol => rol.Rol)
                    .Include(rol => rol.JobTitle)
                    .Include(rol => rol.Department).ToList();

                return _mapper.Map<List<GetUser>>(listUser).Count(c => c.RolDescription == "Empleado");
            }
            catch
            {
                throw new GetUsersFailedException();
            }
        }

        public async Task<int> GetManagerUsersAsync()
        {
            try
            {
                var userQuery = await _userRepository.VerifyDataExistenceAsync();
                var listUser = userQuery
                    .Include(rol => rol.Rol)
                    .Include(rol => rol.JobTitle)
                    .Include(rol => rol.Department).ToList();

                return _mapper.Map<List<GetUser>>(listUser).Count(c => c.RolDescription == "Gerente");
            }
            catch
            {
                throw new GetUsersFailedException();
            }
        }

        public async Task<int> GetRRHHUsersAsync()
        {
            try
            {
                var userQuery = await _userRepository.VerifyDataExistenceAsync();
                var listUser = userQuery
                    .Include(rol => rol.Rol)
                    .Include(rol => rol.JobTitle)
                    .Include(rol => rol.Department).ToList();

                return _mapper.Map<List<GetUser>>(listUser).Count(c => c.RolDescription == "Recursos Humanos");
            }
            catch
            {
                throw new GetUsersFailedException();
            }
        }

        public async Task<int> GetSuperAdminUsersAsync()
        {
            try
            {
                var userQuery = await _userRepository.VerifyDataExistenceAsync();
                var listUser = userQuery
                    .Include(rol => rol.Rol)
                    .Include(rol => rol.JobTitle)
                    .Include(rol => rol.Department).ToList();

                return _mapper.Map<List<GetUser>>(listUser).Count(c => c.RolDescription == "SuperAdmin");
            }
            catch
            {
                throw new GetUsersFailedException();
            }
        }

        public async Task<int> GetSupervisorUsersAsync()
        {
            try
            {
                var userQuery = await _userRepository.VerifyDataExistenceAsync();
                var listUser = userQuery
                    .Include(rol => rol.Rol)
                    .Include(rol => rol.JobTitle)
                    .Include(rol => rol.Department).ToList();

                return _mapper.Map<List<GetUser>>(listUser).Count(c => c.RolDescription == "Supervisor");
            }
            catch
            {
                throw new GetUsersFailedException();
            }
        }

        public async Task<int> GetTotalCustomersAsync()
        {
            try
            {
                var customerQuery = await _customerRepository.VerifyDataExistenceAsync();
                return _mapper.Map<List<GetCustomer>>(customerQuery.ToList()).Count();

            }
            catch
            {
                throw new GetCustomerFailedException();
            }
        }

        public async Task<int> GetTotalSuppliersAsync()
        {
            try
            {
                var supplierQuery = await _supplierRepository.VerifyDataExistenceAsync();
                return _mapper.Map<List<GetSuppliers>>(supplierQuery.ToList()).Count();
            }
            catch
            {
                throw new GetSuppliersFailedException();
            }
        }

        public Task<int> GetTotalInvoiceIssuedAsync()
        {
            throw new NotImplementedException();
        }
        
    }
}
