using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using ContentGuide.Singleton;

namespace ContentGuide.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        string username = string.Empty;
        string password = string.Empty;

        private App app = Application.Current as App;

        public LoginViewModel()
        {
            LoginCommand = new Command(() => {
                authenticate();
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string str)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(str));
        }

        public string Username
        {
            get => username;
            set
            {
                if (username == value)
                {
                    return;
                }
                username = value;
                OnPropertyChanged(nameof(username));
            }
        }

        public string Password
        {
            get => password;
            set
            {
                if (password == value)
                {
                    return;
                }
                password = value;
                OnPropertyChanged(nameof(password));
            }
        }

        public ICommand LoginCommand { get; set; }

        private async void authenticate()
        {
            if (username == "test" && password == "test")
            {
                Application.Current.Properties["username"] = username;
                Application.Current.Properties["password"] = password;
                await Application.Current.SavePropertiesAsync();
                app.navigationMain("main");
            }
            else
            {
                await Nav.Shared.DisplayAlertAsync("Alert", "Invalid credentials", "Try again");
                Username = "";
                Password = "";
            }
        }
    }
}