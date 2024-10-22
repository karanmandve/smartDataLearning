using App.Core.Interface;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace App.Core.Apps.Customer.Command
{
    public class UpdateCustomerByIdCommand : IRequest<object>
    {

        public Domain.Customer Customer { get; set; }
        public int Id { get; set; }
    }



    public class UpdateCustomerByIdCommandHandler : IRequestHandler<UpdateCustomerByIdCommand, object>
    {

        private readonly IAppDbContext _appDbContext;

        public UpdateCustomerByIdCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<object> Handle(UpdateCustomerByIdCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;

            var customer = await _appDbContext.Set<Domain.Customer>().FindAsync(id);

            if (customer == null)
            {
                return new
                {
                    status = 404,
                    message = "Customer Not Found",
                    data = customer
                };
            }



            customer.FirstName = request.Customer.FirstName;
            customer.LastName = request.Customer.LastName;
            customer.Age = request.Customer.Age;
            customer.Email = request.Customer.Email;
            customer.PhoneNumber = request.Customer.PhoneNumber;
            customer.Address = request.Customer.Address;
            customer.City = request.Customer.City;
            customer.State = request.Customer.State;
            customer.Country = request.Customer.Country;
            customer.PostalCode = request.Customer.PostalCode;
            customer.Gender = request.Customer.Gender;
            customer.Birthday = request.Customer.Birthday;
            customer.CustomerSince = request.Customer.CustomerSince;
            customer.IsMembershipActive = request.Customer.IsMembershipActive;
            customer.TotalSpent = request.Customer.TotalSpent;
            customer.LastPurchaseDate = request.Customer.LastPurchaseDate;
            customer.PreferredLanguage = request.Customer.PreferredLanguage;
            customer.CustomerStatus = request.Customer.CustomerStatus;
            customer.CustomerRating = request.Customer.CustomerRating;
            customer.IsCustomerActive = request.Customer.IsCustomerActive;

            await _appDbContext.SaveChangesAsync(cancellationToken);
            var respose = new
            {
                status = 200,
                message = "Customer updated succesffuly",
                data = customer
            };

            return respose;
        }
    }



}

