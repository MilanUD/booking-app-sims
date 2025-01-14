﻿using BookingApp.Domain.Model;
using BookingApp.Repository;
using BookingApp.View.Owner;
using BookingApp.WPF.Views.Owner;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookingApp.View.Guest1
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        private readonly User _user;
        private readonly AccommodationRepository _accommodationRepository;
        private readonly ReservationRepository _reservationRepository;
        public HomeWindow(User user)
        {
            InitializeComponent();
            DataContext = this;
            _reservationRepository = new ReservationRepository();
            _accommodationRepository = new AccommodationRepository();
            _user = user;
            CheckReviewNotifications();
        }
        
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            RegisterAccomodation registerAccomodation = new RegisterAccomodation(_user);
            registerAccomodation.ShowDialog();
        }

        private void Reviews_Click(object sender, RoutedEventArgs e)
        {
            AccommodationReviews accommodationReviews = new AccommodationReviews(_user);
            accommodationReviews.ShowDialog();
        }

        private void CheckReviewNotifications()
        {
            var list = _accommodationRepository.GetAllOwnerAccommodations(_user.Id).Select(a => a.Id).ToList();
            foreach (var r in _reservationRepository.GetAllUnreviewed(list))
            {
                GuestReviewForm guestReviewForm = new GuestReviewForm(r);
                guestReviewForm.Show();
            }

        }

        private void Requests_Click(object sender, RoutedEventArgs e)
        {
            ChangeReservationRequests changeReservationRequest = new ChangeReservationRequests(_user);
            changeReservationRequest.Show();
        }

        private void Accommodations_Click(object sender, RoutedEventArgs e)
        {
            RenovationView renovationView = new RenovationView(_user);
            renovationView.Show();
        }

        private void Renovations_Click(object sender, RoutedEventArgs e)
        {
            RenovationReview renovationReview = new RenovationReview(_user);
            renovationReview.Show();
        }

        private void Forums_Click(object sender, RoutedEventArgs e)
        {
            ForumsWindow forums= new();
            forums.Show();
        }

        private void Reccommmendations_Click(object sender, RoutedEventArgs e)
        {
            AccommodationProposition propositions = new();
            propositions.Show();
        }





    }
}
