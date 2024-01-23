using System;
using LibraryApp.Model;
using System.Collections.ObjectModel;
using LibraryApp.Model;
namespace LibraryApp.ViewModel
{
	public class ProfileClass
	{
		public Customer customer = new Customer { Login = "aaaaa.@gmail.com", Name = "Jurek", Surname = "Ogórek" };
		public string Name { get { return customer.Name; } }
        public string Surname { get { return customer.Surname; } }
        public ProfileClass()
		{
        }
	}
}

