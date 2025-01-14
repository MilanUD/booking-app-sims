﻿using BookingApp.Serializer;
using System;

namespace BookingApp.Domain.Model
{
    public class RenovationRecommendation : ISerializable
    {

        public int Id { get; set; }
        public int ReservationId { get; set; }
        public int AccomodationId { get; set; }
        public int UserId { get; set; }
        public string Condition { get; set; }
        public int RenovationUrgency { get; set; }
        public DateTime RecommendationDate { get; set; }


        public RenovationRecommendation()
        {
        }

        public RenovationRecommendation(int reservationId, int accomodationId, int userId, string condition, int revovur)
        {
            ReservationId = reservationId;
            AccomodationId = accomodationId;
            UserId = userId;
            Condition = condition;
            RenovationUrgency = revovur;
            RecommendationDate = DateTime.Now;
        }



        public string[] ToCSV()
        {
            string[] csvValues = {
                Id.ToString(),
                ReservationId.ToString(),
                AccomodationId.ToString(),
                UserId.ToString(),
                Condition,
                RenovationUrgency.ToString(),
                      RecommendationDate.ToString(),
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = Convert.ToInt32(values[0]);
            ReservationId = Convert.ToInt32(values[1]);
            AccomodationId = Convert.ToInt32(values[2]);
            UserId = Convert.ToInt32(values[3]);
            Condition = values[4];
            RenovationUrgency = Convert.ToInt32(values[5]);
            RecommendationDate = Convert.ToDateTime(values[6]);
        }



    }
}