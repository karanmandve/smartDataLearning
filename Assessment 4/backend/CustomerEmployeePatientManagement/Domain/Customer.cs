using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int State { get; set; }
        public int Country { get; set; }
        public string PostalCode { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CustomerSince { get; set; }
        public bool IsMembershipActive { get; set; }
        public decimal TotalSpent { get; set; }
        public DateTime LastPurchaseDate { get; set; }
        public string PreferredLanguage { get; set; }
        public string CustomerStatus { get; set; }
        public int CustomerRating { get; set; }
        public bool IsCustomerActive { get; set; }
    }

}
