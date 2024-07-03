using AutoMapper;
using Siged.Application.Customers.Interfaces;
using Siged.Domain.Interfaces;
using Siged.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siged.Application.Customers.DTOs;
using Siged.Application.Roles.DTOs;
using Siged.Application.Roles.Exceptions;
using Siged.Application.Customers.Exceptions;
using Siged.Application.Users.DTOs;
using Siged.Application.Users.Exceptions;
using Siged.Application.Users.Validators;
using Siged.Domain.Enums;
using Siged.Application.Customers.Validators;
using FluentValidation;
using Siged.Application.Authentication.Exceptions;

namespace Siged.Application.Customers.Servicices
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> _CustomerRepository;
        private readonly IMapper _mapper;

        public CustomerService(IGenericRepository<Customer> customerRepository, IMapper mapper)
        {
            _CustomerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCustomer>> GetAllCustomerAsync()
        {
            try
            {
                var rol = await _CustomerRepository.VerifyDataExistenceAsync();
                return _mapper.Map<List<GetCustomer>>(rol.ToList());

            }
            catch
            {
                throw new GetCustomerFailedException();
            }
        }
        public async Task<GetCustomer> Register(CreateCustomer model)
        {
            try
            {
                var createUserValidator = new CreateCustomeValidator();
                var validationResult = createUserValidator.Validate(model);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                    throw new TaskCanceledException($"{string.Join(", ", errors)}");
                }

                var CustomerCreated = await _CustomerRepository.CreateAsync(_mapper.Map<Customer>(model));

                var userException = CustomerCreated.CustomerId == (int)DataCreationOption.DoNotCreate ? throw new UserNotCreatedException() : CustomerCreated;

               // Ahora verificamos y recuperamos los datos del cliente recién creado con todas las entidades relacionadas
                var createdCustomerWithRelations = await _CustomerRepository
                    .GetByIdAsync(CustomerCreated.CustomerId); // Suponiendo un método GetByIdAsync en _customerRepository

                return _mapper.Map<GetCustomer>(createdCustomerWithRelations);

                

            }
            catch
            {
                throw;
            }

        }

        public async Task<bool> UpdateAsync(UpdateCustomer model)
        {
            try
            {
                var validator = new UpdateCustomrValidator();
                var validationResult = await validator.ValidateAsync(model);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                    throw new TaskCanceledException(string.Join(", ", errors));
                }

                var userModel = _mapper.Map<Customer>(model);

                var userFound = await _CustomerRepository.GetEverythingAsync(u => u.CustomerId == userModel.CustomerId);

                var CustomerToUpdate = userFound ?? throw new UserNotFoundException();

                CustomerToUpdate.IdentificationCard = userModel.IdentificationCard;
                CustomerToUpdate.FullName = userModel.FullName;
                CustomerToUpdate.PhoneNumber = userModel.PhoneNumber;
                CustomerToUpdate.Email = userModel.Email;
              
               

                bool response = await _CustomerRepository.UpdateAsync(CustomerToUpdate);

                bool isUpdateSuccessful = !response ? throw new UpdateUserFailedException() : response;

                return response;
            }
            catch
            {
                throw;
            }
        }
        public  async Task<bool> DeleteAsync(int id)
        {

            try
            {
                var CustomerFound = await _CustomerRepository.GetEverythingAsync(u => u.CustomerId == id);

                var CustomrDelete = CustomerFound ?? throw new UserNotFoundException();

                bool response = await _CustomerRepository.DeleteAsync(CustomerFound);

                var isDeleteSuccessful = response ? response : throw new DeleteUserFailedException();

                return response;
            }
            catch
            {
                throw new DeleteUserErrorFailedException();
            }
        }

        
        public async Task<GetCustomer> GetCustomerByIdAsync(int id)
        {

            try
            {
                var user = await _CustomerRepository.GetByIdAsync(id);
                if (user == null)
                    throw new UserNotFoundException(); // Implementa esta excepción según tu lógica de manejo de errores

                return _mapper.Map<GetCustomer>(user);
            }
            catch
            {
                throw;
            }
        }

       

       
    }
}
