using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace LibraryApp.ViewModel
{
	public class SignUpClass
	{
        public ICommand goBack => new Command(() => Application.Current.MainPage.Navigation.PopAsync());
		public ICommand SignIn => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new SignIn()));
        public SignUpClass()
		{

		}
	}
}

