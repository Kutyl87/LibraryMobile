using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using LibraryGrpc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Grpc.Net.Client;
using System.Net.Http;
using Grpc.Net.Client.Web;
using LibraryApp.Model;
using Xamarin.Essentials;
using static LibraryGrpc.CustomerIt;

namespace LibraryApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListBooks : ContentPage
    {
        private GrpcChannel channel;

        public ListBooks()
        {
            InitializeComponent();

        }
        //private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        //{

        //    if (e.CurrentSelection.Count > 0)
        //    {

        //        var selectedItem = e.CurrentSelection[0] as Book;
        //        await Navigation.PushAsync(new BookPage(selectedItem));
        //        Listbook.SelectedItem = null;
        //    }
        //}
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            //channel = GrpcChannel.ForAddress("https://libraryappgrpc.azurewebsites.net", new GrpcChannelOptions
            //{
            //    HttpHandler = new GrpcWebHandler(new HttpClientHandler())
            //});

            //var bookClient = new BookIt.BookItClient(channel);
            //var orderClient = new OrderIt.OrderItClient(channel);


            Book book = (Book)((ListView)sender).SelectedItem;
            await Navigation.PushAsync(new BookPage(book));
            ((ListView)sender).SelectedItem = null;
            //string userIdString = SecureStorage.GetAsync("userId").Result;
            //int userId = int.Parse(userIdString);
            //var bookRequest = new UpdateBookRequest { Id = book.BookId, CurrentOwnerId = userId };
            //var orderRequest = new CreateOrderRequest { OrderId = 1, BookId = book.BookId, CustomerId = userId };

            //string result = await DisplayActionSheet($"Selected Book: {book.Title}", "Cancel", null, "Confirm");

            //if (result == "Confirm")
            //{
            //    var bookResponse = bookClient.UpdateBook(bookRequest);
            //    var orderResponse = orderClient.CreateOrder(orderRequest);
            //    Application.Current.MainPage.Navigation.PushAsync(new ListItems());
            //}

            ////Deselect Item
            //((ListView)sender).SelectedItem = null;
        }
    }
}
