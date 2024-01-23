using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace LibraryApp.ViewModel
{
    public class Categories
    {
        public ObservableCollection<string> ListCategories { get; set; }
        public ICommand OnFocus => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new SearchPage()));
        public ICommand GoToProfile => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new ProfilePage()));
        public Categories()
        {
            ListCategories = new ObservableCollection<string>
        {
            "Action",
            "Adventure",
            "Animation",
            "Comedy",
            "Drama",
            "Fantasy",
            "Horror",
            "Mystery",
            "Romance",
            "Sci-Fi",
            "Thriller",
            "Documentary",
            "Family",
            "Musical",
            "Western",
            "Slice of Life",
            "Sports",
            "Superpower",
            "Magic",
            "Psychological",
            "Supernatural",
            "Mecha",
            "Shoujo",
            "Shounen",
            "Seinen",
            "Josei",
            "Historical",
            "Harem",
            "Music"
        };

        }

    }
}
