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
                if(user.Password == txtPassword.Password && user.Role == Roles.OWNER)
                {
                    HomeWindow homeWindow= new HomeWindow(user);
                    homeWindow.Show();
                    Close();
                } 
                else if(user.Password == txtPassword.Password && user.Role == Roles.GUEST)
                {
                    Guest1Window guest1Window = new Guest1Window(user);
                    guest1Window.Show();
                    Close();
                }else if(user.Password == txtPassword.Password && user.Role == Roles.TOURIST)
                {
                    TouristWindow touristWindow = new TouristWindow(user);
                    touristWindow.Show();
                    Close();

                }else if(user.Password == txtPassword.Password && user.Role == Roles.GUIDE)
                {
                    GuideWindow guideWindow = new GuideWindow(user);
                    guideWindow.Show();
                    Close();

                }
            }
            else
            {
                MessageBox.Show("Wrong username!");
            }
            
        }
    }
}
