﻿using BookingApp.Dto;
using BookingApp.Model;
using BookingApp.Repository;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace BookingApp.View.Owner
{
    /// <summary>
    /// Interaction logic for RegisterAccomodation.xaml
    /// </summary>
    public partial class RegisterAccomodation : Window, INotifyPropertyChanged
    {
        private readonly AccommodationRepository _accommodationRepository;
        private readonly ReservationRepository _reservationRepository;
        private readonly User _user;
        
        public AccommodationDto Accommodation { get; set; }
       

        public RegisterAccomodation(User user)
        {
            InitializeComponent();
            DataContext = this;
            _user = user;
            _accommodationRepository = new AccommodationRepository();
            _reservationRepository = new ReservationRepository();

            Accommodation = new AccommodationDto();
            Accommodation.UserId = user.Id;

            CheckReviewNotifications();

        }

        private void NewAccommodationRegistration(object sender, RoutedEventArgs e)
        {
            string isValidAccomodation = Accommodation.IsValid;

            if (isValidAccomodation == string.Empty)
            {
                Accommodation newAccommodation = Accommodation.ToModel();
                _accommodationRepository.Save(newAccommodation);
                this.Close();
            } else
            {
                ErrorMessage.Visibility = Visibility.Visible;
                ErrorMessage.Content = isValidAccomodation;
            }

        }




        private void CancelButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
    }
}