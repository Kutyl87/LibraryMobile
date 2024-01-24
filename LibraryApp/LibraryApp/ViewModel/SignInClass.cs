using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using LibraryGrpc;
using System.ComponentModel;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;

namespace LibraryApp.ViewModel
{
    public class SignInClass : INotifyPropertyChanged
    {
        private GrpcChannel channel;

        public event PropertyChangedEventHandler PropertyChanged;

        private string propertySignUp = "Sign Up!";
        public string PropertySignUp
        {
            get { return propertySignUp; }
        }

        private string messageSignIn = " ";
        public string MessageSignIn
        {
            get { return messageSignIn; }
            set
            {
                if (messageSignIn != value)
                {
                    messageSignIn = value;
                    OnPropertyChanged(nameof(MessageSignIn));
                }
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public ICommand GoBack => new Command(() => Application.Current.MainPage.Navigation.PopAsync());
        public ICommand Login { set; get; }
        public ICommand LabelTappedCommand => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new SignUp()));

        public SignInClass()
        {
            Login = new Command(OnSubmit);
        }

        public void OnSubmit()
        {
            Application.Current.MainPage.Navigation.PushAsync(new ListItems());
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                channel = GrpcChannel.ForAddress("https://libraryappgrpc.azurewebsites.net", new GrpcChannelOptions
                {
                    HttpHandler = new GrpcWebHandler(new HttpClientHandler())
                });

                var customerClient = new AuthIt.AuthItClient(channel);
                var signInRequest = new LogInRequest { Email = email, Password = password };

                var signInResponse = customerClient.LogInUser(signInRequest);

                if (signInResponse.IsSuccess)
                {
                    Application.Current.MainPage.Navigation.PushAsync(new ListItems());
                }
                else
                {
                    MessageSignIn = signInResponse.Message;
                }
            }
            else
            {
                MessageSignIn = "Fill the data";
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
