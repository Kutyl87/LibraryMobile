using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using LibraryApp.Model;
using System.Threading.Tasks;

namespace LibraryApp.ViewModel
{
    public class SearchClass
    {
        private readonly string[] BookTitles = new[] {
                "The Catcher in the Rye",
                "To Kill a Mockingbird",
                "1984",
                "Pride and Prejudice",
                "The Great Gatsby",
                "Harry Potter and the Sorcerer's Stone",
                "The Hobbit",
                "The Da Vinci Code",
                "The Lord of the Rings",
                "The Hitchhiker's Guide to the Galaxy",
                "The Shining",
                "The Hunger Games",
                "The Chronicles of Narnia",
                "The Godfather",
                "The Girl with the Dragon Tattoo",
                "Brave New World",
                "Animal Farm",
                "The Alchemist",
                "One Hundred Years of Solitude",
                "The Road",
                "Frankenstein",
                "Dracula",
                "The Picture of Dorian Gray",
                "Wuthering Heights",
                "Jane Eyre",
                "Sense and Sensibility",
                "The Color Purple",
                "Moby-Dick",
                "Alice's Adventures in Wonderland"
            };

        public ICommand OnTextChange { get; }
        public ICommand GoToProfile => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new ProfilePage()));
        public ObservableCollection<Book> Books { get; set; }
        public ObservableCollection<Book> bookdisplayed { get; set; }
        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                if (searchText != value)
                {
                    searchText = value;
                }
            }
        }
        public SearchClass()
        {
            OnTextChange = new Command(() => TextChanged(SearchText));
            Books = new ObservableCollection<Book>();
            bookdisplayed = new ObservableCollection<Book>();
            for (int i = 0; i < BookTitles.Length; i++)
            {
                Book book = new Book
                {
                    BookId = i + 1,
                    Title = BookTitles[i],
                    Author = "Adam Jan Czubak",
                    Genre = "Fiction",
                    Rating = 4.7f,
                    Availability = true,
                    BookDescription = "Description of the bookxx xxxxxodosfjsi  fjisaifijsifisjaifs  aifjasjifasifia  jiaifjiasi  jfaif  jis fs fsafffa fsf aa ff.",
                    CurrentOwnerId = null,
                    ImageUrl = "test2.png"
                };

                Books.Add(book);
                bookdisplayed.Add(book);
            }
        }
        void TextChanged(string searchTerm)
        {

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = string.Empty;
            }
            searchTerm = searchTerm.ToLowerInvariant();
            var filteredItems = BookTitles.Where(value =>
             value.ToLowerInvariant().Contains(searchTerm)).ToList();
            
            foreach (var value in BookTitles)
            {
                if(!filteredItems.Contains(value))
                {
                    var booksToRemove = Books.Where(book => book.Title == value).ToList();
                    foreach (var bookToRemove in booksToRemove)
                    {
                        bookdisplayed.Remove(bookToRemove);
                    }
                }
                foreach (var org_book in Books)
                {
                    if (filteredItems.Contains(org_book.Title) && !bookdisplayed.Any(book => org_book.BookId == book.BookId))
                    {
                        bookdisplayed.Add(org_book);
                    }
                }   

            }
        }
    }
}

