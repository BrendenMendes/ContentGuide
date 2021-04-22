using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using ContentGuide.Services;
using ContentGuide.Singleton;
using Xamarin.Forms;

namespace ContentGuide.ViewModels
{
    public class SignUpViewModel : INotifyPropertyChanged
    {
        string name = string.Empty;
        string email_address = string.Empty;
        string password = string.Empty;

        private App app = Application.Current as App;

        public SignUpViewModel()
        {
            SignUpCommand = new Command(() =>
            {
                signupAsync();
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string str)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(str));
        }

        public string Name
        {
            get => name;
            set
            {
                if (name == value)
                {
                    return;
                }
                name = value;
                OnPropertyChanged(nameof(name));
            }
        }

        public string EmailAddress
        {
            get => email_address;
            set
            {
                if (email_address == value)
                {
                    return;
                }
                email_address = value;
                OnPropertyChanged(nameof(email_address));
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

        public ICommand SignUpCommand { get; set; }

        private bool emailAuth(string email)
        {
            Console.WriteLine(email);
            Regex rg = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            MatchCollection match = rg.Matches(email);
            if (match.Count == 1)
            {
                return true;
            }
            return false;
        }

        private bool passwordAuth(string password)
        {
            Console.WriteLine(password);
            Regex rg = new Regex("^[a-zA-Z0-9_]*$");
            MatchCollection match = rg.Matches(password);
            if (match.Count == 1)
            {
                return true;
            }
            return false;
        }

        private async System.Threading.Tasks.Task signupAsync()
        {
            if (emailAuth(email_address) && passwordAuth(password))
            {
                NetworkCalls networkCalls = new NetworkCalls();
                string token = networkCalls.Signup(name, email_address, password);
                Console.WriteLine(token);
                if (token != "null")
                {
                    Application.Current.Properties["username"] = name;
                    Application.Current.Properties["emailAddress"] = email_address;
                    Application.Current.Properties["password"] = password;
                    Application.Current.Properties["token"] = token;
                    await Application.Current.SavePropertiesAsync();
                    app.navigationMain("login");
                }
                else
                {
                    await Nav.Shared.DisplayAlertAsync("Alert", "There was an issue registering your details", "Try again");
                    name = "";
                    EmailAddress = "";
                    Password = "";
                }
            }
            else
            {
                await Nav.Shared.DisplayAlertAsync("Alert", "Invalid credentials", "Try again");
                Name = "";
                EmailAddress = "";
                Password = "";
            }
        }
    }
}
