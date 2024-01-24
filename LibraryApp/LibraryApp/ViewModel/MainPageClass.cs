using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace LibraryApp.ViewModel
{
	public class MainPageClass: INotifyPropertyChanged
	{
		public ICommand SignIn => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new SignIn()));
        public ICommand SignUp => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new SignUp()));
        public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string name="")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
		public MainPageClass()
		{
		}
	}
}

