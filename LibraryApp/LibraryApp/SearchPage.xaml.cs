using System;
using System.Collections.Generic;
using LibraryApp.Model;
using Xamarin.Forms;

namespace LibraryApp
{	
	public partial class SearchPage : ContentPage
	{	
		public SearchPage ()
		{
			InitializeComponent ();
		}
		private async void OnItemSelected(object sender ,SelectionChangedEventArgs e)
		{
            //var details = e.Item as Book;
            //await Navigation.PushAsync(new BookPage(details));
            if (e.CurrentSelection.Count > 0)
            {
                // Pobranie wybranego elementu
                var selectedItem = e.CurrentSelection[0] as Book;
                await Navigation.PushAsync(new BookPage(selectedItem));
                // Navigacja do nowej strony, przekazując dane

                // Wyczyszczenie zaznaczenia w CollectionView
                BookCollection.SelectedItem = null;
            }
        }
	}
}

