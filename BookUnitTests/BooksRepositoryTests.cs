using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using BooksRepositoryLibrary;

namespace BookUnitTests
{
    [TestClass]
    public class BooksRepositoryTests
    {
        private IBooksRepository _booksRepository; 

        [TestInitialize]
        public void Init()
        {
            _booksRepository = new BooksRepository();

            _booksRepository.Add(new Book() { Title ="A Tale of Two Cities", Price = 330 });
            _booksRepository.Add(new Book() { Title ="The Hobbit", Price = 600 });    
            _booksRepository.Add(new Book() { Title ="The Great Gatsby", Price = 500 });
            _booksRepository.Add(new Book() { Title ="Harry Potter and the Goblet of Fire", Price = 250 });
        }

        [TestMethod()]
        public void GetTest()
        {
            IEnumerable<Book> books = _booksRepository.Get();
            Assert.AreEqual(10, books.Count());
            Assert.AreEqual(books.First().Title, "A Tale of Two Cities");

            IEnumerable<Book> sortedBooks = _booksRepository.Get(orderBy: "title");
            Assert.AreEqual(sortedBooks.First().Title, "A Tale of Two Cities");

            IEnumerable<Book> sortedBooks2 = _booksRepository.Get(orderBy: "price");
            Assert.AreEqual(sortedBooks2.First().Title, "Harry Potter and the Goblet of Fire");
        }

        [TestMethod()]
        public void AddTest()
        {
            Book book = new() { Title = "Test", Price = 400 };
            Assert.AreEqual(10, _booksRepository.Add(book).Id);
            Assert.AreEqual(11, _booksRepository.Get().Count());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.AreEqual(10, _booksRepository.Get().Count());
            Book book = new() { Title = "Test", Price = 400 };
            Assert.IsNull(_booksRepository.Update(20, book));
            Assert.AreEqual(1, _booksRepository.Update(1, book)?.Id);
            Assert.AreEqual(10, _booksRepository.Get().Count());
        }




    }
}
