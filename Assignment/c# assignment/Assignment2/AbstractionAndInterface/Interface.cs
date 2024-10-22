using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AbstractionAndInterface
{
    // Defining the IPaymentMethod Interface
    public interface IPaymentMethod
    {
        void ProcessPayment();
        bool ValidatePaymentDetails();
    }

    // inhariting the IPayment method
    public class CreadiCardPayment : IPaymentMethod
    {

        private readonly decimal _amount;

        public CreadiCardPayment(decimal amount)
        {
            _amount = amount;
        }

        /// <summary>
        /// Processing the payment details
        /// </summary>
        public void ProcessPayment() {

            Console.WriteLine($"Processing Payment done of amount: {_amount}");

        }

        /// <summary>
        /// Validating payment details
        /// </summary>
        public bool ValidatePaymentDetails()
        {
            return true;
        }

    }

    // inhariting the IPayment method
    public class UpiPayment : IPaymentMethod
    {

        private readonly decimal _amount;

        public UpiPayment(decimal amount)
        {
            _amount = amount;
        }

        /// <summary>
        /// Processing the payment details
        /// </summary>
        public void ProcessPayment()
        {

            Console.WriteLine($"Processing Payment done of amount: {_amount}");

        }

        /// <summary>
        /// Validating payment details
        /// </summary>
        public bool ValidatePaymentDetails()
        {
            return true;
        }
    }


}
