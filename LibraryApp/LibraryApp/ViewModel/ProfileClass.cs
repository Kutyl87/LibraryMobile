using System;
using LibraryApp.Model;
using System.Collections.ObjectModel;
using LibraryApp.Model;
using System.Windows.Input;
using Xamarin.Forms;

namespace LibraryApp.ViewModel
{
	public class ProfileClass
	{
		public Customer customer = new Customer { Login = "aaaaa.@gmail.com", Name = "Jurek", Surname = "Ogórek" };
        public ICommand LogOut => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new MainPage()));
        public ICommand MyOrders => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new UserOrders()));
        public string Name { get { return customer.Name; } }
        public string Surname { get { return customer.Surname; } }
        public ProfileClass()
		{
        }
	}
}

