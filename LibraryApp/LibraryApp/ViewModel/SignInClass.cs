using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace LibraryApp.ViewModel
{
	public class SignInClass
	{
		public string PropertySignUp { get; } = "Sign Up!";
        public ICommand goBack => new Command(() => Application.Current.MainPage.Navigation.PopAsync());
		public ICommand Login => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new WelcomePage()));
		public ICommand LabelTappedCommand => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new SignUp()));
        public SignInClass()
		{

		}
	}
}

