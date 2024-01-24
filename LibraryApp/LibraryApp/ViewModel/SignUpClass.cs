using System;
using System.Windows.Input;
using Google.Api;
using Xamarin.Forms;

namespace LibraryApp.ViewModel
{
	public class SignUpClass
	{
        public ICommand goBack => new Command(() => Application.Current.MainPage.Navigation.PopAsync());
		public ICommand SignIn => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new SignIn()));
        public ICommand Register { get; set; }
		public string name;
		public string surname;
		public string email;
		public string password;
		public string repeatPassword;
        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                }
            }

        }
        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                }
            }

        }
        public string  Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                }
            }

        }
        public string Surname
        {
            get { return surname; }
            set
            {
                if (surname != value)
                {
                    surname = value;
                }
            }

        }
        public string RepeatPassword
        {
            get { return repeatPassword; }
            set
            {
                if (repeatPassword != value)
                {
                    repeatPassword = value;
                }
            }

        }
        public SignUpClass()
		{
            Register = new Command(onSubmit);
        }
        public void onSubmit()
        {
            if(email=="test")
            {
                Application.Current.MainPage.Navigation.PushAsync(new ListItems());
            }
        }
	}
}

