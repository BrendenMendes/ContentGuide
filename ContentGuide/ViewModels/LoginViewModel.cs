using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using ContentGuide.Singleton;
using ContentGuide.Services;
using System.Text.RegularExpressions;
using ContentGuide.Views;
using Newtonsoft.Json;
using System.Linq;

namespace ContentGuide.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        string username = string.Empty;
        string password = string.Empty;

        private App app = Application.Current as App;

        public LoginViewModel(INavigation navigation)
        {
            LoginCommand = new Command(() => {
                authenticate();
            });

            SignUpCommand = new Command(() =>
            {
                signup();
            });
            this.Navigation = navigation;
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
        public ICommand SignUpCommand { get; set; }

        private bool emailAuth(string email) {
            Console.WriteLine(email);
            Regex rg = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            MatchCollection match = rg.Matches(email);
            if(match.Count == 1)
            {
                return true;
            }
            return false;
        }

        private bool passwordAuth(string password) {
            Console.WriteLine(password);
            Regex rg = new Regex("^[a-zA-Z0-9_]*$");
            MatchCollection match = rg.Matches(password);
            if(match.Count == 1)
            {
                return true;
            }
            return false;
        }

        private async void authenticate()
        {
            if (emailAuth(username) && passwordAuth(password))
            {
                NetworkCalls networkCalls = new NetworkCalls();
                string loginData = networkCalls.Login(username, password);
                var data = JsonConvert.DeserializeObject<Login>(loginData);
                Console.WriteLine(data.Token);
                Console.WriteLine(data.Name);
                Console.WriteLine(data.Preferences.Count());
                if (data.Token != "null")
                {
                    Application.Current.Properties["username"] = username;
                    Application.Current.Properties["name"] = data.Name;
                    Application.Current.Properties["password"] = password;
                    Application.Current.Properties["token"] = data.Token;
                    if (data.Preferences.Count() > 0)
                    {
                        Application.Current.Properties["preferences"] = JsonConvert.SerializeObject(data.Preferences);
                        app.navigationMain("home");
                    }
                    else
                    {
                        app.navigationMain("genre");
                    }
                    await Application.Current.SavePropertiesAsync();
                }
                else
                {
                    await Nav.Shared.DisplayAlertAsync("Alert", "There was an issue logging you in. Re-check the email address and/or password", "Try again");
                    Username = "";
                    Password = "";
                }
            }
            else
            {
                await Nav.Shared.DisplayAlertAsync("Alert", "Invalid credentials", "Try again");
                Username = "";
                Password = "";
            }
        }

        private void signup()
        {
            //app.navigationMain("signup");
            Navigation.PushAsync(new SignUpPage());
        }
    }
}