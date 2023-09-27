using BooksRepositoryLibrary;

namespace BookUnitTests
{
    [TestClass]
    public class BookTests
    {
        private readonly Book _book = new() { Id = 1, Title = "title1", Price = 400 };
        private readonly Book _bookTitleNull = new() { Id = 2, Price = 400 };
        private readonly Book _bookTitleShort = new Book() { Id = 3, Title = "a", Price = 400 };
        private readonly Book _bookPriceHigh = new Book() { Id = 4, Title = "title2", Price = 1600 };
        private readonly Book _bookPriceLow = new Book() { Id = 5, Title = "title", Price = -10 };

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("1 title1 400", _book.ToString());
        }
        
        [TestMethod()]
        public void ValidateTitleTest()
        {
            _book.ValidateTitle();
            Assert.ThrowsException<ArgumentNullException>(() => _bookTitleNull.ValidateTitle());
            Assert.ThrowsException<ArgumentException> (() => _bookTitleShort.ValidateTitle());
        }

        [TestMethod()]
        public void ValidatePriceTest()
        {
            _book.ValidatePrice();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>  _bookPriceHigh.ValidatePrice());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _bookPriceLow.ValidatePrice());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            _book.Validate();
        }









    }
}