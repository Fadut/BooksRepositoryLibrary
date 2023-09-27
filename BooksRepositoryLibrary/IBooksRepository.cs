namespace BooksRepositoryLibrary
{
    public interface IBooksRepository
    {
        Book Add(Book Book);
        Book? Delete(int id);
        IEnumerable<Book> Get(int? Price = null, string? titleIncludes = null, string? orderBy = null);
        Book? GetById(int id);
        Book? Update(int id, Book Book);
    }
}