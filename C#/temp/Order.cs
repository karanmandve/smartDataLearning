using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temp
{
    public class Order
    { 

        public Order(string item, DateTime date)
        {

            _item = item;
            if (date.Year == DateTime.Now.Year)
            {
                _date = date;
            }
            else
            {
                _date = new DateTime(0001, 1, 1);
            }
            // _date = date;
        }

        private string _item;
        public string Item
        {
            get
            {
                return _item;
            }

        }

        private DateTime _date;
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                if (value.Year == DateTime.Now.Year)
                {
                    _date = value;
                }
            }



        }
    }
}
