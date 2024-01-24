using Grpc.Net.Client;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Grpc.Net.Client.Web;
using LibraryGrpc;
using System.Net.Http;

namespace LibraryApp.ViewModel
{
    public class BooksByCategory
    {
        private readonly GrpcChannel channel;
        public ObservableCollection<string> ListBooksByCategory { get; set; }
        public ICommand OnFocus => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new SearchPage()));
        public ICommand GoToProfile => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new ProfilePage()));
        public BooksByCategory()
        {

            channel = GrpcChannel.ForAddress("https://libraryappgrpc.azurewebsites.net", new GrpcChannelOptions
            {
                HttpHandler = new GrpcWebHandler(new HttpClientHandler())
            });
            var bookClient = new BookIt.BookItClient(channel);
            var category = ListItems.SelectedCategory;
            var bookRequest = new GetBooksByCategoryRequest { Category = category };
            var listBookResponse = bookClient.GetBooksByCategory(bookRequest);
            ListBooksByCategory = new ObservableCollection<string>();
            foreach(var book in listBookResponse.Book)
            {
                ListBooksByCategory.Add(book.Title);
            }
       
        }

    }
}
