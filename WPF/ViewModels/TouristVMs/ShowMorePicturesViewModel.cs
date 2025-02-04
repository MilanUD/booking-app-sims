﻿using BookingApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.WPF.ViewModels.TouristVMs
{
    public class ShowMorePicturesViewModel: IRequestClose
    {
        public event EventHandler<DialogCloseRequestedEventArgs> RequestClose;

        public RelayCommand BackButtonCommand {  get; set; }
        public TourInstance TourInstance { get; set; }
        public ShowMorePicturesViewModel(TourInstance tourInstance)
        {
            TourInstance = tourInstance;
            BackButtonCommand = new RelayCommand(GoBack);
        }

        public void GoBack()
        {
            RequestClose?.Invoke(this, new DialogCloseRequestedEventArgs(false));
        }

    }
}
