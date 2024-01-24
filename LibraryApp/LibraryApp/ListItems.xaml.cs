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

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            SelectedCategory = ((ListView)sender).SelectedItem.ToString();
            //Deselect Item
               
            Application.Current.MainPage.Navigation.PushAsync(new ListBooks());
            ((ListView)sender).SelectedItem = null;
        }
    }
}

