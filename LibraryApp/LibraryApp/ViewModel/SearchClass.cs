using Grpc.Net.Client.Web;
using Grpc.Net.Client;
using LibraryApp.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Windows.Input;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Xamarin.Forms;
using LibraryGrpc;
using static LibraryGrpc.CustomerIt;
using System;
using System.Collections.Generic;

namespace LibraryApp.ViewModel
{
    public class BookTitleComparer : IEqualityComparer<Book>
    {
        public bool Equals(Book x, Book y)
        {
            return x.Title == y.Title;
        }

        public int GetHashCode(Book obj)
        {
            return obj.Title.GetHashCode();
        }
    }
    public class SearchClass
    {
        private readonly GrpcChannel channel;

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
            channel = GrpcChannel.ForAddress("https://libraryappgrpc.azurewebsites.net", new GrpcChannelOptions
            {
                HttpHandler = new GrpcWebHandler(new HttpClientHandler())
            });
            var bookClient = new BookIt.BookItClient(channel);
            var bookRequest = new GetAllBookRequest { };
            var bookResponse = bookClient.ListBook(bookRequest);
            Books = new ObservableCollection<Book>();
            OnTextChange = new Command(() => TextChanged(SearchText));
            bookdisplayed = new ObservableCollection<Book>();
            foreach (var bookElem in bookResponse.Book)
            {
                if (bookElem.Availability)
                {
                    Book book = new Book
                    {
                        BookId = bookElem.Id,
                        Title = bookElem.Title,
                        Author = bookElem.Author,
                        Genre = bookElem.Genre,
                        Rating = bookElem.Rating,
                        Availability = bookElem.Availability,
                        BookDescription = bookElem.Description,
                        CurrentOwnerId = bookElem.CurrentOwnerId,
                        ImageUrl = bookElem.ImageUrl
                    };
                    Books.Add(book);
                    bookdisplayed.Add(book);

                }

            }
            bookdisplayed = new ObservableCollection<Book>(Books.Distinct(new BookTitleComparer()));
            Books = new ObservableCollection<Book>(Books.Distinct(new BookTitleComparer()));



        }
        void TextChanged(string searchTerm)
        {
            bookdisplayed.Clear();
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                searchTerm = string.Empty;
            }
            searchTerm = searchTerm.ToLowerInvariant();
            var filteredItems = Books.Where(book =>
            book.Title.ToLowerInvariant().Contains(searchTerm)).ToList();

            foreach (var book in filteredItems)
            {
                bookdisplayed.Add(book);
            }
        }
    }
}

