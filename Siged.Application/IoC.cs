using Microsoft.Extensions.DependencyInjection;
using Siged.Application.Attendances;
using Siged.Application.Attendances.Interfaces;
using Siged.Application.Authentication.Interfaces;
using Siged.Application.Authentication.Services;
using Siged.Application.Customers.Interfaces;
using Siged.Application.Customers.Servicices;
using Siged.Application.Departments.Interfaces;
using Siged.Application.Departments.Services;
using Siged.Application.JobTitles.Interfaces;
using Siged.Application.JobTitles.Services;
using Siged.Application.Menus.Interfaces;
using Siged.Application.Menus.Services;
using Siged.Application.Roles.Interfaces;
using Siged.Application.Roles.Services;
using Siged.Application.Salarys.Interfaces;
using Siged.Application.Salarys.Services;
using Siged.Application.TaskEmployees.Interfaces;
using Siged.Application.TaskEmployees.Services;
using Siged.Application.Suppliers.Interfaces;
using Siged.Application.Suppliers.Services;
using Siged.Application.Users.Interfaces;
using Siged.Application.Users.Services;
using Siged.Application.Tax.Interfaces;
using Siged.Application.Tax.Services;
using Siged.Application.Payrolls.Interfaces;
using Siged.Application.Payrolls.Services;
using Siged.Application.Goals.Services;
using Siged.Application.Goals.Interfaces;
using Siged.Application.Evaluators.Interfaces;
using Siged.Application.Evaluators.Services;
using Siged.Application.PerformanceEvaluations.Interfaces;
using Siged.Application.PerformanceEvaluations.Services;
using Siged.Application.TaskStatusEmployees.Interfaces;
using Siged.Application.TaskStatusEmployees.Services;
using Siged.Application.ServiceNames.Interfaces;
using Siged.Application.ServiceNames.Services;
using Siged.Application.PaymentMethods.Interfaces;
using Siged.Application.PaymentMethods.Services;
using Siged.Application.AppliedTaxes.Interfaces;
using Siged.Application.AppliedTaxes.Services;
using Siged.Application.DiscountsService.Interface;
using Siged.Application.DiscountsService.Service;
using Siged.Application.PaymenInvoiceStatus.Interfaces;
using Siged.Application.PaymenInvoiceStatus.Services;
using Siged.Application.ActivitiesCalendar.Interfaces;
using Siged.Application.ActivitiesCalendar.Services;
using Siged.Application.ServicePaymentInvoices.Interfaces;
using Siged.Application.ServicePaymentInvoices.Services;

namespace Siged.Application
{
    public static class IoC
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            return service
                .AddScoped<IRolService, RolService>()
                .AddScoped<IDepartamentService, DepartamentService>()
                .AddScoped<IJobTitleService, JobTitleService>()
                .AddScoped<ISalaryService, SalaryService>()
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<IAttendanceService, AttendanceService>()
                .AddScoped<IMenuService, MenuService>()
                .AddScoped<ICustomerService, CustomerService>()
                .AddScoped<ISupplierService, SupplierService>()
                .AddScoped<ITaxesService, TaxesService>()
                .AddScoped<IPayrollService, PayrollService>()
                .AddScoped<IGoalsService, GoalsService>()
                .AddScoped<IEvaluatorsService, EvaluatorsService>()
                .AddScoped<IPerformanceEvaluationService, PerformanceEvalutionService>()
                .AddScoped<ITaskStatusEmployeeService, TaskStatusEmployeeService>()
                .AddScoped<ITaskEmployeeService, TaskEmployeeService>()
                .AddScoped<IServiceNamesService, ServiceNamesService>()
                .AddScoped<IPaymentMethodService, PaymentMethodService>()
                .AddScoped<IAppliedTaxesService, AppliedTaxesService>()
                .AddScoped<IDiscountService, DiscountService>()
                .AddScoped<IPaymentServiceInvoiceStatusService, PaymentServiceInvoiceStatusService>()
                .AddScoped<IActivitiesCalendarService, ActivitiesCalendarService>()
                .AddScoped<IServicePaymentInvoiceService, ServicePaymentInvoiceService>();



        }

    }

}
