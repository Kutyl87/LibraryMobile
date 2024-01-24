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

            if (e.CurrentSelection.Count > 0)
            {

                var selectedItem = e.CurrentSelection[0] as Book;
                await Navigation.PushAsync(new BookPage(selectedItem));
                BookCollection.SelectedItem = null;
            }
        }
	}
}

