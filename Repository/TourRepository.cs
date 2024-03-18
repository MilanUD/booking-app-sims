﻿using BookingApp.Model;
using BookingApp.Observer;
using BookingApp.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace BookingApp.Repository
{
    public class TourRepository : SubjectNotifier
    {
        private const string FilePath = "../../../Resources/Data/tours.csv";

        private readonly Serializer<Tour> _serializer;

        private List<Tour> _tour;

        public TourRepository()
        {
            _serializer = new Serializer<Tour>();
            _tour = _serializer.FromCSV(FilePath);
        }

        public List<Tour> GetAll()
        {
            return _serializer.FromCSV(FilePath);
        }

        public int NextId()
        {
            _tour = _serializer.FromCSV(FilePath);
            if (_tour.Count < 1)
            {
                return 1;
            }
            return _tour.Max(c => c.Id) + 1;
        }

        public Tour JustSave(Tour tour)
        {
            _tour = _serializer.FromCSV(FilePath);
            _tour.Add(tour);
            _serializer.ToCSV(FilePath, _tour);
            return tour;
        }

        public Tour Save(Tour tour)
        {
            tour.Id = NextId();
            _tour = _serializer.FromCSV(FilePath);
            _tour.Add(tour);
            _serializer.ToCSV(FilePath, _tour);
            return tour;
        }

        public Tour GetById(int Id)
        {
            return _tour.Find(x => x.Id == Id);
        }


        public void Delete(Tour tour)
        {
            _tour = _serializer.FromCSV(FilePath);
            Tour founded = _tour.Find(c => c.Id == tour.Id);
            _tour.Remove(founded);
            _serializer.ToCSV(FilePath, _tour);
        }

        public Tour Update(Tour tour)
        {
            _tour = _serializer.FromCSV(FilePath);
            Tour current = _tour.Find(c => c.Id == tour.Id);
            int index = _tour.IndexOf(current);
            _tour.Remove(current);
            _tour.Insert(index, tour);       // keep ascending order of ids in file 
            _serializer.ToCSV(FilePath, _tour);
            return tour;
        }

        public List<Tour> GetByUser(int userId)
        {
            _tour = _serializer.FromCSV(FilePath);
            return _tour.FindAll(c => c.UserId == userId);
        }





    }
}
