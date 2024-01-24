using System.ComponentModel;
using System.Net.Http;
using System.Windows.Input;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using LibraryGrpc;
using Xamarin.Forms;

namespace LibraryApp.ViewModel
{
    public class SignUpClass : INotifyPropertyChanged
    {
        private GrpcChannel channel;

        public event PropertyChangedEventHandler PropertyChanged;

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                if (surname != value)
                {
                    surname = value;
                    OnPropertyChanged(nameof(Surname));
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

        private string repeatPassword;
        public string RepeatPassword
        {
            get { return repeatPassword; }
            set
            {
                if (repeatPassword != value)
                {
                    repeatPassword = value;
                    OnPropertyChanged(nameof(RepeatPassword));
                }
            }
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

        public ICommand GoBack => new Command(() => Application.Current.MainPage.Navigation.PopAsync());
        public ICommand SignIn => new Command(() => Application.Current.MainPage.Navigation.PushAsync(new SignIn()));
        public ICommand Register { get; set; }

        public SignUpClass()
        {
            Register = new Command(OnSubmit);
        }

        public void OnSubmit()
        {
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname) && password == repeatPassword)
            {
                channel = GrpcChannel.ForAddress("https://libraryappgrpc.azurewebsites.net", new GrpcChannelOptions
                {
                    HttpHandler = new GrpcWebHandler(new HttpClientHandler())
                });

                var customerClient = new AuthIt.AuthItClient(channel);
                var signUpRequest = new RegisterRequest
                {
                    Email = email,
                    Name = name,
                    Surname = surname,
                    Password = password,
                    ConfirmPassword = repeatPassword
                };

                var signUpResponse = customerClient.RegisterUser(signUpRequest);

                if (signUpResponse.IsSuccess)
                {
                    Application.Current.MainPage.Navigation.PushAsync(new ListItems());
                }
                else
                {
                    MessageSignIn = signUpResponse.Message;
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
