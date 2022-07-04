using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    // This is the Book class.
    // If an object is created using this class, it will have all of the fields, properties, and methods available to it.
    
    public class TaxRate
    {
        // This is a private field named '_rate'. It stores the current tax rate.

        private decimal _rate;
        
        // This is a property called 'Rate'. The getter will return the current rate. 
        // The setter will check to see if the incoming value is greater than 0 and less than 1, inclusive.
        // If so, then the incoming value becomes the new rate. If not, then the incoming value is ignored.

        public decimal Rate
        {
            get
            {
                return _rate;
            }

            set
            {
                if(value >= 0 && value <=1)
                {
                    _rate = value;     
                }
            }       
        }

        // This is an constructor for the TaxRate class.
        // To create an object from this class, you need to have a variable with the decimal data type.
        // The incoming value will become the tax rate.

        public TaxRate(decimal rate)
        {
            Rate = rate;
        }     
    }
}
