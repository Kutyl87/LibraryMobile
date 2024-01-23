using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

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
        public ObservableCollection<string> Books { get; set; }
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
            Books = new ObservableCollection<string>(BookTitles);
          
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
                    Books.Remove(value);
                }
                else if (!Books.Contains(value))
                {
                    Books.Add(value);
                }
            }
        }
	}
}

