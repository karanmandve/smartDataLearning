using App.core.Apps.Department.Command;
using App.core.Apps.Department.Query;
using App.core.Apps.Employee.Command;
using App.core.Apps.Employee.Query;
using Microsoft.Extensions.DependencyInjection;

namespace App.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg =>
            {
                // FOR EMPLOYEE
                cfg.RegisterServicesFromAssemblyContaining<CreateEmployeeCommand>();
                cfg.RegisterServicesFromAssemblyContaining<UpdateEmployeeByIdCommand>();
                cfg.RegisterServicesFromAssemblyContaining<DeleteEmployeeByIdCommand>();
                cfg.RegisterServicesFromAssemblyContaining<GetEmployeeQuery>();
                cfg.RegisterServicesFromAssemblyContaining<GetEmployeeByIdQuery>();

                // FOR DEPARTMENT
                cfg.RegisterServicesFromAssemblyContaining<CreateDepartmentCommand>();
                cfg.RegisterServicesFromAssemblyContaining<UpdateDepartmentByIdCommand>();
                cfg.RegisterServicesFromAssemblyContaining<DeleteDepartmentByIdCommand>();
                cfg.RegisterServicesFromAssemblyContaining<GetDepartmentQuery>();
                cfg.RegisterServicesFromAssemblyContaining<GetDepartmentByIdQuery>();
            });

            return services;
        }
    }
}
