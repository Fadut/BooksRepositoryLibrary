using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BooksRepositoryLibrary
{
    public class BooksRepository : IBooksRepository
    {
        private readonly List<Book> _books = new();
        private int _nextId = 1;

        public BooksRepository()
        {
            _books.Add(new Book() { Id = 1, Title = "A Tale of Two Cities", Price = 330 });
            _books.Add(new Book() { Id = _nextId++, Title = "The Hobbit", Price = 600 });
            _books.Add(new Book() { Id = _nextId++, Title = "The Great Gatsby", Price = 500 });
            _books.Add(new Book() { Id = _nextId++, Title = "Harry Potter and the Goblet of Fire", Price = 250 });
            _books.Add(new Book() { Id = _nextId++, Title = "Dune", Price = 730 });
            _books.Add(new Book() { Id = _nextId++, Title = "How to Win Friends and Influence People", Price = 640 });
        }

        public IEnumerable<Book> Get(int? Price = null, string? titleIncludes = null, string? orderBy = null)
        {
            IEnumerable<Book> result = new List<Book>(_books);

            // Filter by price
            if (Price != null)
            {
                result = result.Where(b => b.Price > Price);
            }
            if (titleIncludes != null)
            {
                result = result.Where(b => b.Title.Contains(titleIncludes));
            }

            // Sort by title or price
            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "title": // fall through to next case
                    case "title_asc":
                        result = result.OrderBy(b => b.Title);
                        break;
                    case "title_desc":
                        result = result.OrderByDescending(b => b.Title);
                        break;
                    case "price": // fall through
                    case "price_asc":
                        result = result.OrderBy(b => b.Price);
                        break;
                    case "price_desc":
                        result = result.OrderByDescending(b => b.Price);
                        break;
                    default:
                        break; // do nothing

                }
            }
            return result;
        }

        public Book? GetById(int id)
        {
            return _books.Find(Book => Book.Id == id);
        }

        public Book Add(Book Book)
        {
            Book.Validate();
            Book.Id = _nextId++;
            _books.Add(Book);
            return Book;
        }

        public Book? Delete(int id)
        {
            Book? Book = GetById(id);
            if (Book == null)
            {
                return null;
            }
            _books.Remove(Book);
            return Book;
        }

        public Book? Update(int id, Book Book)
        {
            Book.Validate();
            Book? existingBook = GetById(id);
            if (existingBook == null)
            {
                return null;
            }
            existingBook.Title = Book.Title;
            existingBook.Price = Book.Price;
            return existingBook;
        }
    }
}
