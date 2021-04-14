﻿using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using ContentGuide.Singleton;
using ContentGuide.Services;
using System.Text.RegularExpressions;

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

            SignUpCommand = new Command(() =>
            {
                signup();
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
                string token = networkCalls.Login(username, password);
                Console.WriteLine(token);
                if (token != "null")
                {
                    Application.Current.Properties["username"] = username;
                    Application.Current.Properties["password"] = password;
                    Application.Current.Properties["token"] = token;
                    await Application.Current.SavePropertiesAsync();
                    app.navigationMain("main");
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
            app.navigationMain("signup");
        }
    }
}