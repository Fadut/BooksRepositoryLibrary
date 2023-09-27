namespace BooksRepositoryLibrary
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }

        public override string ToString()
        {
            return $"{Id} {Title} {Price}"; 
        }

        public void ValidateTitle()
        {
            if (Title == null)
                throw new ArgumentNullException("Title is null");

            if (Title.Length < 4)
                throw new ArgumentException("Title must be atleast 4 characters " + Title);
        }

        public void ValidatePrice()
        {
            if (Price < 0 || Price > 1200)
                throw new ArgumentOutOfRangeException("Price must be between 0 and 1200 " + Price);
        }

        public void Validate()
        {
            ValidateTitle();
            ValidatePrice();
        }



    }
}