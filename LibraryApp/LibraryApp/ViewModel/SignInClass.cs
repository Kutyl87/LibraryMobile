using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace LibraryApp.ViewModel
{
	public class SignInClass
	{
		public string PropertySignUp { get; } = "Sign Up!";
        public ICommand goBack => new Command(() => Application.Current.MainPage.Navigation.PopAsync());
		public ICommand Login { set; get; }
		public ICommand LabelTappedCommand => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new SignUp()));
		public string email;
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
		public string password;
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
        public SignInClass()
		{
            Login = new Command(onSubmit);
		}
        public void onSubmit()
        {
            if (email == "dupa")
            {
                //TODO
                Application.Current.MainPage.Navigation.PushAsync(new ListItems());
            }
        }
	}
}

