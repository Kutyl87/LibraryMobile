namespace LibraryApp.Model
{
    public class Book
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public float Rating { get; set; }

        public bool Availability { get; set; }

        public string BookDescription { get; set; }

        public int? CurrentOwnerId { get; set; }

        public string ImageUrl { get; set; }

    }
}