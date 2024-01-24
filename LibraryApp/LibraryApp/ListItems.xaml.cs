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
namespace LibraryApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListItems : ContentPage
    {
        public static string SelectedCategory { get; set; }
        public ListItems()
        {
            InitializeComponent();

        }
        /*static async Task Main()
        {
            // Specify the address and port of your gRPC server
            var serverAddress = "localhost";
            var serverPort = 50051;

            // Create a channel to the gRPC server
            var channel = GrpcChannel.ForAddress($"https://{serverAddress}:{serverPort}")
            // Utwórz kanał do komunikacji z serwerem
            using var channel = new grpc::Channel("localhost", 50051, grpc::ChannelCredentials.Insecure);

            // Utwórz klienta gRPC
            var greeterClient = new Greeter.GreeterClient(channel);

            // Utwórz obiekt zapytania
            var request = new HelloRequest { Name = "John" };

            try
            {
                // Wywołaj metodę SayHello synchronicznie
                var response = greeterClient.SayHello(request);
                Console.WriteLine($"Received greeting: {response.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calling SayHello: {ex.Message}");
            }

            try
            {
                // Wywołaj metodę SayHello asynchronicznie
                var responseAsync = await greeterClient.SayHelloAsync(request);
                Console.WriteLine($"Received greeting asynchronously: {responseAsync.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calling SayHello asynchronously: {ex.Message}");
            }
        }*/

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            SelectedCategory = ((ListView)sender).SelectedItem.ToString();
            //Deselect Item
                
            
            Application.Current.MainPage.Navigation.PushAsync(new ListBooks());
            ((ListView)sender).SelectedItem = null;
        }
    }
}

    //    void SearchBar_Focused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
    //    {
    //    }
    //}
