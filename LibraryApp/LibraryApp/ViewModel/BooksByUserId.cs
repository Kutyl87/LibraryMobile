using Grpc.Net.Client;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Grpc.Net.Client.Web;
using LibraryGrpc;
using System.Net.Http;
using LibraryApp.Model;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using System;

namespace LibraryApp.ViewModel
{
    public class BooksByUserId
    {
        private readonly GrpcChannel channel;
        public ObservableCollection<Book> ListBooksByUserId { get; set; }
        public BooksByUserId()
        {

            channel = GrpcChannel.ForAddress("https://libraryappgrpc.azurewebsites.net", new GrpcChannelOptions
            {
                HttpHandler = new GrpcWebHandler(new HttpClientHandler())
            });
            var bookClient = new BookIt.BookItClient(channel);
            string userIdString = SecureStorage.GetAsync("userId").Result;
            var bookRequest = new ListAllBooksByCustomerIdRequest { UserId= int.Parse(userIdString) };
            var listBookResponse = bookClient.GetBooksByUserId(bookRequest);
            Console.WriteLine(userIdString);
            ListBooksByUserId = new ObservableCollection<Book>();

            foreach (var bookElem in listBookResponse.Book)
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
                    ListBooksByUserId.Add(book);

            }
            ListBooksByUserId = new ObservableCollection<Book>(ListBooksByUserId.Distinct(new BookTitleComparer()));

        }

    }
}
