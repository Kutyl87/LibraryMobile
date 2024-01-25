using System;
using System.Collections.Generic;
using Grpc.Net.Client;
using LibraryApp.Model;
using System.Net.Http;
using Xamarin.Forms;
using Grpc.Net.Client.Web;
using LibraryGrpc;
using Xamarin.Essentials;


namespace LibraryApp
{	
	public partial class BookPage : ContentPage
	{
        private GrpcChannel channel;

        private Book _book;
        public BookPage (Book book)
		{
			InitializeComponent ();
			Title.Text = book.Title;
			Author.Text = book.Author;
            Img.Source = book.ImageUrl;
            //Img.Source = "https://cdn11.bigcommerce.com/s-zg6cb2/images/stencil/2560w/products/1633/2251/Chronicles__74223.1626774641.jpg?c=2";
            Description.Text = book.BookDescription;
			Rating.Text = book.Rating.ToString();
			Genre.Text = book.Genre;
            _book = book;

		}

        async void OnButtonClicked(object sender, EventArgs e)
        {

            channel = GrpcChannel.ForAddress("https://libraryappgrpc.azurewebsites.net", new GrpcChannelOptions
            {
                HttpHandler = new GrpcWebHandler(new HttpClientHandler())
            });

            var bookClient = new BookIt.BookItClient(channel);
            var orderClient = new OrderIt.OrderItClient(channel);
            string userIdString = SecureStorage.GetAsync("userId").Result;
            int userId = int.Parse(userIdString);
            var bookRequest = new UpdateBookRequest { Id = _book.BookId, CurrentOwnerId = userId };
            var orderRequest = new CreateOrderRequest { OrderId = 1, BookId = _book.BookId, CustomerId = userId };


            string result = await DisplayActionSheet($"Selected Book: {_book.Title}", "Cancel", null, "Confirm");
            if (result == "Confirm")
            {
                var bookResponse = bookClient.UpdateBook(bookRequest);
                var orderResponse = orderClient.CreateOrder(orderRequest);
                Application.Current.MainPage.Navigation.PushAsync(new ListItems());
            }


        }
    }
}

