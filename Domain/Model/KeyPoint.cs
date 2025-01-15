﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
//using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Xml.Linq;
using BookingApp.Serializer;

namespace BookingApp.Domain.Model
{
    public class KeyPoint : ISerializable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TourId { get; set; }
        public bool Status { get; set; }
        public int Order { get; set; }

        public KeyPoint() { }

        public KeyPoint(int tourId, string name, int order)
        {
            Id = Id;
            TourId = tourId;
            Name = name;
            Status = false;
            Order = order;
        }

        public override string ToString()
        {
            return $"ID: {Id,2} | Naziv: {Name,9} |";
        }


        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                TourId.ToString(),
                Name,
                Order.ToString()

            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            TourId = int.Parse(values[1]);
            Name = values[2];
            Order = int.Parse(values[3]);
        }



    }
}
