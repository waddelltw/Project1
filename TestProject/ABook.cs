using ClassLibrary;

// This is to test the Book class. Below are a series of tests to determine whether if the Book class is working properly.

namespace TestProject
{
    [TestClass]
    public class ABook
    {
        [TestMethod]

        // This tests to see if a book can't have an empty title.

        public void CanNotHaveAnEmptyName()
        {
            string name = "";

            decimal cost = 50M;

            Book sut = new(name, cost);

            Assert.AreEqual(sut.Name, "No Title");
        }

        [TestMethod]

        // This test if a book can't have a price above 9999 or below 0.

        public void CanNotHaveAPriceBelow0OrAbove9999()
        {
            string name = "Test Title";

            decimal cost = -1M;

            Book sut = new(name, cost);

            Assert.AreEqual(sut.CostWithoutTax, 0M);

            sut.CostWithoutTax = 10000M;

            Assert.AreEqual(sut.CostWithoutTax, 0M);
        }

        [TestMethod]

        // This tests whether the book class can calculate the tax for one book.

        public void CanCalculateTaxForOneBook() 
        {
            decimal taxRate = .10M;

            TaxRate tax = new(taxRate);

            string name = "Test Title";

            decimal cost = 100M;

            Book sut = new(name, cost);

            decimal taxAdded = sut.TaxAddedToOneBook(tax);

            Assert.AreEqual(taxAdded, 10M);
        }

        [TestMethod]

        // This tests if the book class can add the tax and cost for one book together.

        public void CanAddTheTaxAndTheCostTogetherForOneBook()
        {
            decimal taxRate = .10M;

            TaxRate tax = new(taxRate);

            string name = "Test Title";

            decimal cost = 100M;

            Book sut = new(name, cost);

            decimal totalCost = sut.TaxAddedToTotalCostOfOneBook(tax);

            Assert.AreEqual(totalCost, 110M);
        }

        [TestMethod]

        // This tests if the book class can calculate tax for multiple books.

        public void CanCalculateTaxForMultipleBooks()
        {
            decimal taxRate = .10M;

            TaxRate tax = new(taxRate);

            string name1 = "Test Title";

            decimal cost1 = 100M;

            string name2 = "Another Title";

            decimal cost2 = 100M;

            Book sut1 = new(name1, cost1);

            Book sut2 = new(name2, cost2);

            decimal totalCostOfMultiple = sut1.CostWithoutTax + sut2.CostWithoutTax;

            decimal taxAdded = sut1.TaxAddedToMultipleBooks(totalCostOfMultiple, tax);

            Assert.AreEqual(taxAdded, 20M);
        }

        [TestMethod]

        // This tests if the book class can add the tax and the cost of multiple books together.

        public void CanAddTheTaxAndTheCostTogetherForMultipleBooks()
        {
            decimal taxRate = .10M;

            TaxRate tax = new(taxRate);

            string name1 = "Test Title";

            decimal cost1 = 100M;

            string name2 = "Another Title";

            decimal cost2 = 100M;

            Book sut1 = new(name1, cost1);

            Book sut2 = new(name2, cost2);

            decimal totalCostOfMultiple = sut1.CostWithoutTax + sut2.CostWithoutTax;

            decimal totalCost = sut1.TaxAddedToTotalCostOfMultipleBooks(totalCostOfMultiple, tax);

            Assert.AreEqual(totalCost, 220M);
        }
    }
}