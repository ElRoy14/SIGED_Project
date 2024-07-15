using AutoMapper;
using Siged.Application.Suppliers.DTOs;
using Siged.Application.Suppliers.Interfaces;
using Siged.Domain.Interfaces;
using Siged.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siged.Application.Customers.DTOs;
using Siged.Application.Customers.Exceptions;
using Siged.Application.Customers.Validators;
using Siged.Application.Users.Exceptions;
using Siged.Domain.Enums;
using Siged.Application.Suppliers.Validators;
using FluentValidation;
using Siged.Application.Authentication.Exceptions;

namespace Siged.Application.Suppliers.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IGenericRepository<Supplier> _SupplierRepository;
        private readonly IMapper _mapper;
       
        public SupplierService(IGenericRepository<Supplier> supplierRepository, IMapper mapper)
        {
            _SupplierRepository = supplierRepository;
            _mapper = mapper;

        }
        public async Task<List<GetSuppliers>> GetAllCustomerAsync()
        {
            try
            {
                var rol = await _SupplierRepository.VerifyDataExistenceAsync();
                return _mapper.Map<List<GetSuppliers>>(rol.ToList());

            }
            catch
            {
                throw new GetCustomerFailedException();
            }
        }
        public async Task<GetSuppliers> Register(CreateSuppliers model)
        {
            try
            {
                var createSupplierValidator = new CreateSupplierValidator();
                var validationResult = createSupplierValidator.Validate(model);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                    throw new TaskCanceledException($"{string.Join(", ", errors)}");
                }

                var SupplierCreated = await _SupplierRepository.CreateAsync(_mapper.Map<Supplier>(model));

                var userException = SupplierCreated.SupplierId == (int)DataCreationOption.DoNotCreate ? throw new UserNotCreatedException() : SupplierCreated;

                // Ahora verificamos y recuperamos los datos del cliente recién creado con todas las entidades relacionadas
                var createdCustomerWithRelations = await _SupplierRepository
                    .GetByIdAsync(SupplierCreated.SupplierId); // Suponiendo un método GetByIdAsync en _customerRepository

                return _mapper.Map<GetSuppliers>(createdCustomerWithRelations);



            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(UpdateSuppliers model)
        {
            try
            {
                var validator = new UpdateSupplierValidator();
                var validationResult = await validator.ValidateAsync(model);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                    throw new TaskCanceledException(string.Join(", ", errors));
                }

                var userModel = _mapper.Map<Supplier>(model);

                var userFound = await _SupplierRepository.GetEverythingAsync(u => u.SupplierId == userModel.SupplierId);

                var SupplierToUpdate = userFound ?? throw new UserNotFoundException();

                SupplierToUpdate.IdentificationCard = userModel.IdentificationCard;
                SupplierToUpdate.FullName = userModel.FullName;
                SupplierToUpdate.PhoneNumber = userModel.PhoneNumber;
                SupplierToUpdate.Email = userModel.Email;



                bool response = await _SupplierRepository.UpdateAsync(SupplierToUpdate);

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
                var SupplierFound = await _SupplierRepository.GetEverythingAsync(u => u.SupplierId == id);

                var CustomrDelete = SupplierFound ?? throw new UserNotFoundException();

                bool response = await _SupplierRepository.DeleteAsync(SupplierFound);

                var isDeleteSuccessful = response ? response : throw new DeleteUserFailedException();

                return response;
            }
            catch
            {
                throw new DeleteUserErrorFailedException();
            }
        }
        public async Task<GetSuppliers> GetCustomerByIdAsync(int id)
        {

            try
            {
                var user = await _SupplierRepository.GetByIdAsync(id);
                if (user == null)
                    throw new UserNotFoundException(); // Implementa esta excepción según tu lógica de manejo de errores

                return _mapper.Map<GetSuppliers>(user);
            }
            catch
            {
                throw;
            }
        }

        

        
    }
}
