﻿using BookingApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingApp.Model;
using System.Collections.ObjectModel;

namespace BookingApp.Services
{
    public class TourRequestService
    {
        private TourRequestRepository TourRequestRepository { get; set; }
        public TourRequestService() { 
            TourRequestRepository = new TourRequestRepository();
        }

        public TourRequest Save(TourRequest tourRequest)
        {
            return TourRequestRepository.Save(tourRequest);
        }

        public List<TourRequest> GetByUserTouristId(int userTouristId) {
            return TourRequestRepository.GetByUserTouristId(userTouristId);
        }
    }
}