namespace ClassLibrary
{
    // This is the Book class.
    // If an object is created using this class, it will have all of the fields, properties, and methods available to it.

    public class Book
    {

        // Here are 2 private fields called '_name' and '_costWithoutTax'.
        // The '_name' field will store a book's name. The '_costWithoutTax' will store a book's price without tax added.

        private string? _name;

        private decimal _costWithoutTax;
       
        // Here is the property called 'Name'. The 'getter' will return the name of the book.
        // The 'setter' will check if the incoming value is blank. If it is not, then that value becomes the book's name.
        // If not, then that book's title will be "No Title".

        public string? Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (value != String.Empty)
                {
                    _name = value;
                }

                else
                {
                    _name = "No Title";
                }            
            }
        }
        
        // Here is the property 'CostWithoutTax'. The 'getter' will return the cost of the book without tax.
        // The 'setter' will check to see if the incoming value is within the values of 0 and 9999. 
        // If so, then that value becomes the cost of the book. If not, then the cost becomes $0.0.

        public decimal CostWithoutTax
        {
            get
            {
                return _costWithoutTax;
            }
        
            set
            {
                if(value >= 0M && value <= 9999M)
                {
                    _costWithoutTax = value;
                }
                
                else
                {
                    _costWithoutTax = 0.0M;
                }
            }       
        }

        // This is a constructor for the book class. For a Book object to be made, you must have a name and price of the book.
        // Both the name and price are stored in their respective fields.

        public Book(string? name, decimal cost)
        {
            Name = name;

            CostWithoutTax = cost;

        }

        // Below are a series of methods that any object in the Book class can use.
        // The first 2 methods both return a value. The method 'TaxAddedToOneBook' returns how much tax will be added to the cost.
        // A parameter for this method an object from the TaxRate class. This method is for if there is only one book available.

        public decimal TaxAddedToOneBook(TaxRate tax)
        {
            return CostWithoutTax * tax.Rate;
        }

        // This method is also used for if there is one book available. This returns the total cost (base cost + tax) of the book.
        // This also has an object from the TaxRate class as a parameter.

        public decimal TaxAddedToTotalCostOfOneBook(TaxRate tax)
        {
            return CostWithoutTax + (CostWithoutTax * tax.Rate);
        }

        // These last 2 methods are for if there are multiple books available. The method 'TaxAddedToMultipleBook' returns...
        // ... the tax that will be added to the original cost of all books currently.
        // This method has a decimal variable called 'totalCostOfAllBooks' and a TaxRate object as parameters.
         
        public decimal TaxAddedToMultipleBooks(decimal totalCostOfAllBooks, TaxRate tax)
        {
            return totalCostOfAllBooks * tax.Rate;
        }

        // This method, 'TaxAddedToTotalCostOfMultipleBooks', returns the total cost (base cost of all books + tax) of the books.

        public decimal TaxAddedToTotalCostOfMultipleBooks(decimal totalCostOfAllBooks, TaxRate tax)
        {
            return totalCostOfAllBooks + (totalCostOfAllBooks * tax.Rate);
        }   
    }
}