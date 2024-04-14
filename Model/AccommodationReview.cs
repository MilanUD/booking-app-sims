﻿using BookingApp.Serializer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Model
{
    public class AccommodationReview : ISerializable
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public int AccomodationId { get; set; }
        public int UserId { get; set; }
        public int Cleanness { get; set; }
        public int Correctness { get; set; }
        public string Description { get; set; }

        public string[] ToCSV()
        {
            string[] csvValues = {
                Id.ToString(),
                ReservationId.ToString(),
                AccomodationId.ToString(),
                UserId.ToString(),
                Cleanness.ToString(),
                Correctness.ToString(),
                Description,
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            ReservationId = Convert.ToInt32(values[1]);
            AccomodationId = Convert.ToInt32(values[2]);
            UserId = Convert.ToInt32(values[3]);
            Cleanness = Convert.ToInt32(values[4]);
            Correctness = Convert.ToInt32(values[5]);
            Description = values[6];
        }
    }
}
