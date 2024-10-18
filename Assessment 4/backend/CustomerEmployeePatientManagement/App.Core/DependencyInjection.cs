using App.Core.Apps.Customer.Command;
using App.Core.Apps.Customer.Query;
using App.Core.Apps.Employee.Command;
using App.Core.Apps.Employee.Query;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(cfg =>
            {
                // FOR CUSTOMER
                cfg.RegisterServicesFromAssemblyContaining<GetCustomerQuery>();
                cfg.RegisterServicesFromAssemblyContaining<CreateCustomerCommand>();
                cfg.RegisterServicesFromAssemblyContaining<UpdateCustomerByIdCommand>();
                cfg.RegisterServicesFromAssemblyContaining<DeleteCustomerByIdCommand>();

                //// FOR EMPLOYEE
                cfg.RegisterServicesFromAssemblyContaining<CreateEmployeeCommand>();
                cfg.RegisterServicesFromAssemblyContaining<DeleteEmployeeCommand>();
                cfg.RegisterServicesFromAssemblyContaining<UpdateEmployeeCommand>();
                cfg.RegisterServicesFromAssemblyContaining<GetEmployeeQuery>();
            });

            return services;
        }

    }
}
