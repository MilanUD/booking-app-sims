﻿using BookingApp.Model;
using BookingApp.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repository
{
    public class TourReservationRepository
    {
        private const string FilePath = "../../../Resources/Data/tourReservation.csv";

        private readonly Serializer<TourReservation> _serializer;

        private List<TourReservation> _tourReservation;

        public TourReservationRepository()
        {
            _serializer = new Serializer<TourReservation>();
            _tourReservation = _serializer.FromCSV(FilePath);
        }

        public int NextId()
        {
            _tourReservation = _serializer.FromCSV(FilePath);
            if (_tourReservation.Count < 1)
            {
                return 1;
            }
            return _tourReservation.Max(c => c.Id) + 1;
        }

        public TourReservation Save(TourReservation tourReservation)
        {
            tourReservation.Id = NextId();
            _tourReservation = _serializer.FromCSV(FilePath);
            _tourReservation.Add(tourReservation);
            _serializer.ToCSV(FilePath, _tourReservation);
            return tourReservation;
        }

        public List<TourReservation> GetAll()
        {
            return _tourReservation;
        }
    }
}
