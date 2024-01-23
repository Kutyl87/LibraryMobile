using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace LibraryApp.ViewModel
{
	public class BookClass
	{
        public ICommand Order => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new ListItems()));
        public BookClass()
		{

		}
	}
}

