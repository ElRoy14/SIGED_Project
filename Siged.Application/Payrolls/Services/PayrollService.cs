using AutoMapper;
using Siged.Domain.Interfaces;
using Siged.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Siged.Application.Payrolls.Interfaces;
using Siged.Application.Tax.DTOs;
using Siged.Application.Tax.Exceptions;
using Siged.Application.Payrolls.DTOs;
using Microsoft.EntityFrameworkCore;
using Siged.Application.Users.DTOs;
using Siged.Application.Users.Exceptions;
using Siged.Application.Users.Validators;
using Siged.Domain.Enums;
using Siged.Application.Payrolls.Validators;
using Siged.Application.Payrolls.Exceptions;
using FluentValidation;
using Siged.Application.Authentication.Exceptions;

namespace Siged.Application.Payrolls.Services
{
    public class PayrollService : IPayrollService
    {
        public readonly IGenericRepository<Payroll> _payrollRepository;
        public readonly IMapper _mapper;

        public PayrollService(IGenericRepository<Payroll> payrollRepository, IMapper mapper)
        {
            _payrollRepository = payrollRepository;
            _mapper = mapper;
        }

        

        public async Task<List<GetPayroll>> GetAllPayrollsAsync()
        {
            try
            {

                var payrolls = await _payrollRepository.VerifyDataExistenceAsync();

                var mappedPayrolls = payrolls.Select(p => new GetPayroll
                {
                    PayrollId = p.PayrollId,
                    UserId = p.UserId,
                    UserName = p.User != null ? p.User.FullName : null,
                    PaymentDate = p.PaymentDate,
                    TaxId = p.TaxId,
                    SalaryAmountUser = p.Tax != null && p.Tax.Salary != null && p.Tax.Salary.Amount != null
                        ? p.Tax.Salary.Amount.ToString()
                        : "0",
                    TaxPercentage = p.Tax != null && p.Tax.Percentage != null && p.Tax.Percentage.PercentageTax != null
                        ? p.Tax.Percentage.PercentageTax.ToString()
                        : "0",
                    NetSalary = p.Tax != null && p.Tax.NetSalary != null ? p.Tax.NetSalary.ToString() : "0"
                }).ToList();

                return mappedPayrolls; ;


            }
            catch
            {
                throw new GetTaxesFailedException();
            }
        }

        public async Task<GetPayroll> Register(CreatePayroll model)
        {
            try
            {
                var createPayrollValidator = new CreatePayrollValidator();
                var validationResult = createPayrollValidator.Validate(model);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                    throw new TaskCanceledException($"{string.Join(", ", errors)}");
                }

                var existingPayroll = await _payrollRepository.VerifyDataExistenceAsync(u => u.UserId == model.UserId);

                if (existingPayroll.Any())
                {
                    throw new UserAlreadyExistsException();
                }

                var payrollCreated = await _payrollRepository.CreateAsync(_mapper.Map<Payroll>(model));

                var payrollException = payrollCreated.PayrollId == (int)DataCreationOption.DoNotCreate ? throw new UserNotCreatedException() : payrollCreated;

                var query = await _payrollRepository.VerifyDataExistenceAsync(u => u.PayrollId == payrollCreated.PayrollId);
                payrollCreated = query
                    .Include(rol => rol.User)
                    .Include(rol => rol.Tax).First();

                return _mapper.Map<GetPayroll>(payrollCreated);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(UpdatePayroll model)
        {
            try
            {
                var validator = new UpdatePayrollValidator();
                var validationResult = await validator.ValidateAsync(model);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                    throw new TaskCanceledException(string.Join(", ", errors));
                }

                var userModel = _mapper.Map<Payroll>(model);

                var userFound = await _payrollRepository.GetEverythingAsync(u => u.PayrollId == userModel.PayrollId);

                var userToUpdate = userFound ?? throw new UserNotFoundException();

                userToUpdate.TaxId = userModel.TaxId;

                bool response = await _payrollRepository.UpdateAsync(userToUpdate);

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
                var userFound = await _payrollRepository.GetEverythingAsync(u => u.PayrollId == id);

                var userDelete = userFound ?? throw new UserNotFoundException();

                bool response = await _payrollRepository.DeleteAsync(userFound);

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
