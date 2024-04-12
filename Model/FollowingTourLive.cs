﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml.Linq;

namespace BookingApp.Model
{
    internal class FollowingTourLive
    {
        public int Id { get; set; }
        public int TourInstanceId { get; set; }
        public KeyPoint KeyPoint { get; set; }
        public List<int> TouristsIds { get; set;} //= new List<Tourist>();

        public FollowingTourLive() {}

        public FollowingTourLive(int tourInstanceId, KeyPoint keyPoint)
        {
            TourInstanceId = tourInstanceId;
            KeyPoint = keyPoint;
            TouristsIds = new List<int>();
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                TourInstanceId.ToString(),
                KeyPoint.Id.ToString(),
                string.Join(",", TouristsForCSV())

            };
            return csvValues;
        }

        public List<string> TouristsForCSV()
        {
            List<string> csvV = new List<string>();
            foreach (int t in TouristsIds)
                {
                    csvV.Add(t.ToString());
                }
            return csvV;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            TourInstanceId = int.Parse(values[1]);
            KeyPoint.Id = int.Parse(values[2]);
            string[] slices = values[3].Split(",").Select(s => s.Trim()).ToArray();
            foreach(string slice in slices)
            {
                TouristsIds.Add(int.Parse(slice));
            }

        }

}
}