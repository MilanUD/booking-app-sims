﻿using BookingApp.Model;
using BookingApp.Repository;
using BookingApp.View.Guest1;
using BookingApp.View.Owner;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace BookingApp.View
{
    /// <summary>
    /// Interaction logic for SignInForm.xaml
    /// </summary>
    public partial class SignInForm : Window
    {

        private readonly UserRepository _repository;

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                if (value != _username)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public SignInForm()
        {
            InitializeComponent();
            DataContext = this;
            _repository = new UserRepository();
        }

        private void SignIn(object sender, RoutedEventArgs e)
        {
            User user = _repository.GetByUsername(Username);
            if (user != null)
            {
                if(user.Password == txtPassword.Password)
                {
                    if(user.Role == Roles.OWNER)
                    {
                        RegisterAccomodation registerAccomodation = new RegisterAccomodation(user);
                        registerAccomodation.Show();
                        Close();
                    }
                    else if(user.Role == Roles.GUEST)
                    {
                        AccomodationView accomodationView = new AccomodationView(user);
                        accomodationView.Show();
                        Close();
                    }
                    else if(user.Role == Roles.TOURIST)
                    {
                        TouristWindow touristWindow = new TouristWindow(user);
                        touristWindow.Show();
                        Close();
                    }
                    else if(user.Role == Roles.GUIDE)
                    {
                        GuideWindow guideWindow = new GuideWindow(user);
                        guideWindow.Show();
                        Close();
                    }
                }  
            }
            else
            {
                MessageBox.Show("Username or password is wrong!");
            }          
        }
    }
}