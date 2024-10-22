using App.Core.Apps.Customer.Command;
using App.Core.Apps.Customer.Query;
using App.Core.Apps.Employee.Command;
using App.Core.Apps.Employee.Query;
using App.Core.Apps.Patient.Command;
using App.Core.Apps.Patient.Query;
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
                cfg.RegisterServicesFromAssemblyContaining<GetAllCustomer>();
                cfg.RegisterServicesFromAssemblyContaining<GetActiveCustomerQuery>();
                cfg.RegisterServicesFromAssemblyContaining<CreateCustomerCommand>();
                cfg.RegisterServicesFromAssemblyContaining<UpdateCustomerByIdCommand>();
                cfg.RegisterServicesFromAssemblyContaining<DeleteCustomerByIdPermanentCommand>();

                //// FOR EMPLOYEE
                cfg.RegisterServicesFromAssemblyContaining<CreateEmployeeCommand>();
                cfg.RegisterServicesFromAssemblyContaining<DeleteEmployeePermanentCommand>();
                cfg.RegisterServicesFromAssemblyContaining<UpdateEmployeeCommand>();
                cfg.RegisterServicesFromAssemblyContaining<GetAllEmployeeQuery>();
                cfg.RegisterServicesFromAssemblyContaining<GetActiveCustomerQuery>();

                // FOR PATIENT
                cfg.RegisterServicesFromAssemblyContaining<CreatePatientCommand>();
                cfg.RegisterServicesFromAssemblyContaining<DeletePatientByIdPermanentCommand>();
                cfg.RegisterServicesFromAssemblyContaining<UpdatePatientByIdCommand>();
                cfg.RegisterServicesFromAssemblyContaining<GetAllPatientQuery>();
                cfg.RegisterServicesFromAssemblyContaining<GetActiveCustomerQuery>();

            });

            return services;
        }

    }
}
