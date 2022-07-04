using ClassLibrary;

// Here, a few variables are declared such as "choice", "numberOfBooks", "bookTitle", "bookCost", "totalCostOfBooks...
// ... "yesOrNo", "changedTaxRate". "ORIGINAL_TAX_RATE" and "MAXIMUM_NUMBER_OF_BOOKS" are inialized with values.
// Also, a new object from the TaxRate class is created with the original tax rate.
// Additionally, 3 objects from the Book class are set to null.

const decimal ORIGINAL_TAX_RATE = .1M;

decimal changedTaxRate;

TaxRate taxRate = new(ORIGINAL_TAX_RATE);

Book? book1 = null; 

Book? book2 = null; 

Book? book3 = null;

string? bookTitle;

decimal bookCost;

decimal totalCostOfBooks;

const int MAXIMUM_NUMBER_OF_BOOKS = 3;

int numberOfBooks = 0;

string? choice;

string? yesOrNo;

//Below is the beginning of the do-while loop. This will allow the user to keep on using the program until the user enters in 9.

do
{
    MainMenu(); // This is a method that shows the main menu. It shows what the user can do.

    choice = Console.ReadLine(); // After the user see the main menu, they enter in a numbered choice of 1 through 9.

    // If the user entered anything but the values of 1-9, then this loop begins.
    // It will keep on repeating until the user enters the values of 1-9.

    while(choice != "1" && choice != "2" && choice != "3" && choice != "4" && choice != "5" && choice != "6" && choice != "7" && choice != "8" && choice != "9")
    {
        Console.WriteLine("Only choices from 1 to 9 are available!");

        Console.WriteLine();

        MainMenu();

        choice = Console.ReadLine();
    }

    // If the choice made by the user was through the values of 1-3, then the AddingBookDetails method is called.
    // The 'choice' variable will be used in the 'AddingBookDetails' method to decide with book object will be made.

    if (choice == "1" || choice == "2" || choice == "3")
    {
        // If you don't have 3 books added already, then you can add a book's details. 

        if (numberOfBooks < MAXIMUM_NUMBER_OF_BOOKS) 
        {
            Console.WriteLine();

            AddingBookDetails();
        }

        // If you already have 3 books, you can't add more. So, this is displayed.

        else
        {
            Console.WriteLine("You already have the maximum amount of books.");

            Console.WriteLine();
        }
    }

    // If the user entered 4, 5, or 6, you will remove a books details.
    // To remove book 1's details, enter 4. To remove book 2's details, enter 5. To remove book 3's details, enter 6.

    if (choice == "4" || choice == "5" || choice == "6")
    {
        Console.WriteLine();

        RemovingBookDetails();
    }

    // If 7 was entered, the program will show all of the books that are currently entered in, via the method 'ShowingAllBooksCurrently'.

    if (choice == "7")
    {
        Console.WriteLine();

        ShowingAllBooksCurrently();
    }

    // If 8 was entered, the program will call the method 'ChangeTaxRate'.

    if (choice == "8")
    {
        Console.WriteLine();

        ChangeTaxRate();
    }

} while (choice != "9");

// Below is the method to show the main menu and what options they can pick.

void MainMenu()
{
    Console.WriteLine("1 - Enter the details about book 1");

    Console.WriteLine("2 - Enter the details about book 2");

    Console.WriteLine("3 - Enter the details about book 3");

    Console.WriteLine("4 - Remove book 1 details");

    Console.WriteLine("5 - Remove book 2 details");

    Console.WriteLine("6 - Remove book 3 details");

    Console.WriteLine("7 - Show all books");

    Console.WriteLine($"8 - Set the tax rate (current: {Math.Round(taxRate.Rate * 100,2)}%)"); 

    Console.WriteLine("9 - Exit");

    Console.Write("Please make a choice: ");
}

// Below is the method for adding book details. First, the programs asks the user to enter the book's title.
// If the book title is empty, the program will keep on asking the user to enter the title. The program moves on after they do this.

void AddingBookDetails()
{
    Console.Write("Please enter the book's title: ");

    bookTitle = Console.ReadLine();

    while (bookTitle == string.Empty)
    {
        Console.WriteLine("Title cannot be blank!");

        Console.Write("Please enter the book's title: ");

        bookTitle = Console.ReadLine();
    }

    // Once they enter the title., the program will ask the user for the book's price.
    // If the book's price is less than $0 or greater than $9999, then the program will say that the cost must be between 0 and 9999.
    // Once they enter the price, a new Book object is created.

    Console.Write("Please enter the book's cost: $");

    bookCost = Convert.ToDecimal(Console.ReadLine());

    while (bookCost < 0M || bookCost > 9999M)
    {
        Console.WriteLine("The cost must be between 0 and 9999!");

        Console.Write("Please enter the book's cost: $");

        bookCost = Convert.ToDecimal(Console.ReadLine());
    }

    // If "1" was selected, 'book1' is created.
    // If "2" was selected, 'book2' is created. If "3" was selected, then 'book3' is created.
    // Finally, the 'numberOfBooks' variable increases by 1.
    // The program goes back to the main menu.

    if (choice == "1" && book1 == null)
    { 
        book1 = new(bookTitle, bookCost);

        numberOfBooks++;
    }
    
    else if (choice == "2" && book2 == null)
    {
        book2 = new(bookTitle, bookCost);

        numberOfBooks++;
    }

    else if (choice == "3" && book3 == null)
    {
        book3 = new(bookTitle, bookCost);

        numberOfBooks++;
    }

    // If a book is already stored in an object, then the program will say that a book is already stored in here.
    // The user must remove book details before they can stored another book in the same location.

    else
    {
        Console.WriteLine("A book already is stored in this location.");
    }

    Console.WriteLine(); // This is for spacing.
}

// Below is the method for removing book details.
// Whichever option you pick, they all nearly the same operation. The only thing that changes is which book you want to remove.

void RemovingBookDetails()
{
    // Below is an if statement for if the user selected "4" and 'book1' isn't null. 
    // The program tells the user that they are about to remove book 1's details.
    // Then, the programs asks the user to enter 'y' to remove to book or 'n' to not remove the book.
    // The answer is stored in the 'yesOrNo' variable.

    if (choice == "4" && book1 != null)
    {
        Console.WriteLine($"You are removing '{book1.Name}'");

        Console.Write("Press ‘y’ to remove or ‘n’ to not remove: ");

        yesOrNo = Console.ReadLine();

        // If the user entered anything other than 'Y', 'y', 'N', or 'n', This loop will begin.
        // This loop will keep on asking the user to enter 'y' or 'n' until the user does so.

        while (yesOrNo != "y" && yesOrNo != "Y" && yesOrNo != "n" && yesOrNo != "N")
        {
            Console.WriteLine("Please enter 'y' or 'n'!");

            Console.WriteLine($"You are removing '{book1.Name}'");

            Console.Write("Press ‘y’ to remove or ‘n’ to not remove: ");

            yesOrNo = Console.ReadLine();
        }

        // If 'Y' or 'y' was entered, a book object will go null. Since "4" was selected, 'book1' will become null.
        // Also, the 'numberOfBooks' variable is decreased by 1.
        // Finally, the program will say that the book was removed.

        if (yesOrNo == "Y" || yesOrNo == "y")
        {
            book1 = null;

            numberOfBooks--;

            Console.WriteLine("The book was removed.");
        }
        
        // If the user entered 'N' or 'n', then 'book1' will not be set to null.
        // The program will say that the book was not removed. 

        else
        {
            Console.WriteLine("The book was not removed.");
        }    
    }

    // This does the same thing as the last if statement. The only difference is that this is for book 2.

    else if (choice == "5" && book2 != null)
    {
        Console.WriteLine($"You are removing '{book2.Name}'");

        Console.Write("Press ‘y’ to remove or ‘n’ to not remove: ");

        yesOrNo = Console.ReadLine();

        while (yesOrNo != "y" && yesOrNo != "Y" && yesOrNo != "n" && yesOrNo != "N")
        {
            Console.WriteLine("Please enter 'y' or 'n'!");

            Console.WriteLine($"You are removing '{book2.Name}'");

            Console.Write("Press ‘y’ to remove or ‘n’ to not remove: ");

            yesOrNo = Console.ReadLine();
        }

        if (yesOrNo == "Y" || yesOrNo == "y")
        {
            book2 = null;

            numberOfBooks--;

            Console.WriteLine("The book was removed.");
        }

        else
        {
            Console.WriteLine("The book was not removed.");
        }
    }

    // This does the same as the last two if and else-if statements for book1 and book2, except this is for book 3.

    else if (choice == "6" && book3 != null)
    {
        Console.WriteLine($"You are removing '{book3.Name}'");

        Console.Write("Press ‘y’ to remove or ‘n’ to not remove: ");

        yesOrNo = Console.ReadLine();

        while (yesOrNo != "y" && yesOrNo != "Y" && yesOrNo != "n" && yesOrNo != "N")
        {
            Console.WriteLine("Please enter 'y' or 'n'!");

            Console.WriteLine($"You are removing '{book3.Name}'");

            Console.Write("Press ‘y’ to remove or ‘n’ to not remove: ");

            yesOrNo = Console.ReadLine();
        }

        if (yesOrNo == "Y" || yesOrNo == "y")
        {
            book3 = null;

            numberOfBooks--;

            Console.WriteLine("The book was removed.");
        }

        else
        {
            Console.WriteLine("The book was not removed.");
        }
    }

    // This will only display if the user entered "4" while 'book1' was null, or the user entered "5" while 'book2" was null...
    // ... or the user entered "6" while 'book3' was null.

    else
    {
        Console.WriteLine("There is no book here to be deleted.");
    }

    Console.WriteLine(); // This is for spacing.
}


// Below is the method for if the user picked "7".
// This will give the user a summary of how many books they currently have, the current tax rate, and how much those books cost.

void ShowingAllBooksCurrently()
{
    // This If- else-if - else statement determines how many books the user currently has and displays that.

    if(numberOfBooks == 0)
    {
        Console.WriteLine("There are no books.");
    }    
    
    else if (numberOfBooks == 1)
    {
        Console.WriteLine("There is one book.");
    }
    
    else if (numberOfBooks == 2)
    {
        Console.WriteLine("There are two books.");
    }
    
    else
    {
        Console.WriteLine("There are three books.");
    }

    // Below this are a series of if-else statement for determining if either book 1, 2, or 3 do exist.
    // If book 1 is null, the program says that there is no book for book 1.
    // If not, then the program displays book 1's name and how much it costs.
    // The rest of these if statement function the same, except they are for book 2 and book 3.

    if (book1 == null)
    { 
        Console.WriteLine($"Book 1: No Book ");
    }
    
    else
    {
        Console.WriteLine($"Book 1: {book1.Name}, {string.Format("{0:C2}", book1.CostWithoutTax)}");
    }

    if (book2 == null)
    {
        Console.WriteLine($"Book 2: No Book ");
    }
    
    else
    {
        Console.WriteLine($"Book 2: {book2.Name}, {string.Format("{0:C2}", book2.CostWithoutTax)}");
    }

    if (book3 == null)
    {
        Console.WriteLine($"Book 3: No Book ");
    }
    
    else
    {
        Console.WriteLine($"Book 3: {book3.Name}, {string.Format("{0:C2}",book3.CostWithoutTax)}");
    }

    // This shows the current tax rate.

    Console.WriteLine($"Tax Rate: {Math.Round(taxRate.Rate * 100M,2)}%");

    Console.WriteLine(); // This blank line is for spacing.

    // Below is a series of if statements determining the cost for the book or books.
    // All will display the cost without tax and with tax.
    // This series is to cover any possibility that might happen.
    // With this first statment, it checks whether 'book1', 'book2',and 'book3' are not null.

    if (book1 != null && book2 != null && book3 != null)
    {
        // If true, the cost of all 3 books is added into the 'totalCostOfBooks' variable. Then, the total cost without tax is shown.
        // Next, to calculate the total tax that will be added, a book object's method will be used.
        // The 'totalCostOfBooks' variable and the 'taxRate' object are passed into this. Then, the total tax is displayed.
        // Finally, the tax is added to the total cost. This is done with a book object's method.
        
        totalCostOfBooks = book1.CostWithoutTax + book2.CostWithoutTax + book3.CostWithoutTax;
    
        Console.WriteLine($"Total Cost        : {string.Format("{0:C2}",totalCostOfBooks)}");

        Console.WriteLine($"Total Tax         : {string.Format("{0:C2}", book1.TaxAddedToMultipleBooks(totalCostOfBooks, taxRate))}");

        Console.WriteLine($"Total Cost + Tax  : {string.Format("{0:C2}", book1.TaxAddedToTotalCostOfMultipleBooks(totalCostOfBooks, taxRate))}");
    }

    // This if statement triggers if the only book 1's details are entered. 
    // The total cost, total tax, and the total cost with tax is all displayed.
    // The calculations are done within the book1's methods.
    
    else if (book1 != null && book2 == null && book3 == null)
    {
        Console.WriteLine($"Total Cost        : {string.Format("{0:C2}", book1.CostWithoutTax)}");

        Console.WriteLine($"Total Tax         : {string.Format("{0:C2}", book1.TaxAddedToOneBook(taxRate))}");

        Console.WriteLine($"Total Cost + Tax  : {string.Format("{0:C2}", book1.TaxAddedToTotalCostOfOneBook(taxRate))}");
    }

    // This if statement triggers if the details for book 1 and 2 were entered.
    // It shows the total cost, total tax, and the combined total of the two.

    else if (book1 != null && book2 != null && book3 == null)
    {
        totalCostOfBooks = book1.CostWithoutTax + book2.CostWithoutTax;

        Console.WriteLine($"Total Cost        : {string.Format("{0:C2}", totalCostOfBooks)}");

        Console.WriteLine($"Total Tax         : {string.Format("{0:C2}", book1.TaxAddedToMultipleBooks(totalCostOfBooks, taxRate))}");

        Console.WriteLine($"Total Cost + Tax  : {string.Format("{0:C2}", book1.TaxAddedToTotalCostOfMultipleBooks(totalCostOfBooks, taxRate))}");
    }

    // This if statement triggers if the details for book 1 and 3 were entered.
    // It shows the total cost, total tax, and the combined total of the two.

    else if (book1 != null && book2 == null && book3 != null)
    {
        totalCostOfBooks = book1.CostWithoutTax + book3.CostWithoutTax;

        Console.WriteLine($"Total Cost        : {string.Format("{0:C2}", totalCostOfBooks)}");

        Console.WriteLine($"Total Tax         : {string.Format("{0:C2}", book1.TaxAddedToMultipleBooks(totalCostOfBooks, taxRate))}");

        Console.WriteLine($"Total Cost + Tax  : {string.Format("{0:C2}", book1.TaxAddedToTotalCostOfMultipleBooks(totalCostOfBooks, taxRate))}");
    }

    // This if statement triggers if the only book 2's details are entered. 
    // The total cost, total tax, and the total cost with tax is all displayed.
    // The calculations are done within the book2's methods.

    else if (book1 == null && book2 != null && book3 == null)
    {
        Console.WriteLine($"Total Cost        : {string.Format("{0:C2}", book2.CostWithoutTax)}");

        Console.WriteLine($"Total Tax         : {string.Format("{0:C2}", book2.TaxAddedToOneBook(taxRate))}");

        Console.WriteLine($"Total Cost + Tax  : {string.Format("{0:C2}", book2.TaxAddedToTotalCostOfOneBook(taxRate))}");
    }

    // This if statement triggers if the details for book 2 and 3 were entered.
    // It shows the total cost, total tax, and the combined total of the two.

    else if (book1 == null && book2 != null && book3 != null)
    {
        totalCostOfBooks = book2.CostWithoutTax + book3.CostWithoutTax;

        Console.WriteLine($"Total Cost        : {string.Format("{0:C2}", totalCostOfBooks)}");

        Console.WriteLine($"Total Tax         : {string.Format("{0:C2}", book2.TaxAddedToMultipleBooks(totalCostOfBooks, taxRate))}");

        Console.WriteLine($"Total Cost + Tax  : {string.Format("{0:C2}", book2.TaxAddedToTotalCostOfMultipleBooks(totalCostOfBooks, taxRate))}");
    }

    // This if statement triggers if the only book 3's details are entered. 
    // The total cost, total tax, and the total cost with tax is all displayed.
    // The calculations are done within the book3's methods.

    else if (book1 == null && book2 == null && book3 != null)
    {
        Console.WriteLine($"Total Cost        : {string.Format("{0:C2}", book3.CostWithoutTax)}");

        Console.WriteLine($"Total Tax         : {string.Format("{0:C2}", book3.TaxAddedToOneBook(taxRate))}");

        Console.WriteLine($"Total Cost + Tax  : {string.Format("{0:C2}", book3.TaxAddedToTotalCostOfOneBook(taxRate))}");
    }

    // This if statement triggers if none of the books' details were entered.
    // Since none were entered, the cost and tax would be $0.00.

    else
    {
        Console.WriteLine($"Total Cost        : $0.00");

        Console.WriteLine($"Total Tax         : $0.00");

        Console.WriteLine($"Total Cost + Tax  : $0.00");
    }

    // Finally, the program asks the user to press enter to go back to main menu.
    // Once the user does this, the program displays the main menu again.

    Console.WriteLine("Please press enter to go back to the main menu...");

    Console.ReadKey();

    Console.WriteLine(); // This is for spacing.
}

// This is a method for if the user entered "8".

void ChangeTaxRate()
{
    // At first, the program will display the current tax rate.
    // Then the program will ask the user the enter the new tax rate.
    // That new tax rate is stored in the 'changedTaxRate' variable.

    Console.WriteLine($"Current Tax Rate: {Math.Round(taxRate.Rate * 100, 0)}%");

    Console.Write("Please enter the new tax rate: ");

    changedTaxRate = Convert.ToDecimal(Console.ReadLine());

    // If the entered tax rate is less than 0 or greater than 1, this loop will start. 
    // The program will tell the user to enter a value from 0 to 1 inclusive and ask them to enter a tax rate.
    // Once the tax rate is valid, the program will exit to loop.

    while (changedTaxRate < 0M || changedTaxRate > 1M)
    {
        Console.Write("Please enter a value from 0 to 1 inclusive. ");

        Console.WriteLine();

        Console.WriteLine($"Current Tax Rate: {Math.Round(taxRate.Rate * 100, 0)}%");

        Console.Write("Please enter the new tax rate: ");

        changedTaxRate = Convert.ToDecimal(Console.ReadLine());
    }

    // The original tax rate will be replaced with the new tax rate, and the program will show that the rate was changed.

    taxRate.Rate = changedTaxRate;

    Console.WriteLine("The tax rate was changed.");

    Console.WriteLine(); // This is here for spacing.
}

