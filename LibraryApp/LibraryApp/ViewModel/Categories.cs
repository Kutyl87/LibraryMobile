using Grpc.Net.Client;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Grpc.Net.Client.Web;
using LibraryGrpc;
using System.Net.Http;

namespace LibraryApp.ViewModel
{
    public class Categories
    {
        private readonly GrpcChannel channel;
        public ObservableCollection<string> ListCategories { get; set; }
        public ICommand OnFocus => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new SearchPage()));
        public ICommand GoToProfile => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new ProfilePage()));
        public Categories()
        {

            channel = GrpcChannel.ForAddress("https://libraryappgrpc.azurewebsites.net", new GrpcChannelOptions
            {
                HttpHandler = new GrpcWebHandler(new HttpClientHandler())
            });
            var bookClient = new BookIt.BookItClient(channel);
            var bookRequest = new ListCategoriesRequest { };
            var listCategoryResponse = bookClient.ListCategories(bookRequest);
            ListCategories = new ObservableCollection<string>();
            foreach(var category in listCategoryResponse.Category)
            {
                ListCategories.Add(category);
            }
       
        }

    }
}
