﻿using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts.Wpf;
using LiveCharts;
using System.Windows.Input;
using BookingApp.Domain.Model;

namespace BookingApp.WPF.ViewModels.TouristVMs
{
    public class PlotGraphViewModel
    {
        public SeriesCollection SeriesCollection { get; set; }
        public ICommand GoBackCommand { get; set; }
        MainViewModel MainViewModel { get; set; }
        public User LoggedInUser {  get; set; }

        public string XAxisTitle { get; set; } 
        public IDialogService _dialogService;

        public PlotGraphViewModel(Dictionary<string, int> dataDictionary, string xAxisTitle, MainViewModel mainViewModel, User loggedInUser, IDialogService dialogService)
        {
            SeriesCollection = new SeriesCollection();

            foreach (var item in dataDictionary)
            {
                SeriesCollection.Add(new ColumnSeries
                {
                    Title = item.Key,
                    Values = new ChartValues<int> { item.Value }
                });
            }

            Labels = dataDictionary.Keys.ToArray();
            Formatter = value => value.ToString("N0"); 
            XAxisTitle = xAxisTitle; 
            MainViewModel = mainViewModel;
            GoBackCommand = new RelayCommand(GoBack);
            LoggedInUser = loggedInUser;
            _dialogService = dialogService;
        }

        public void GoBack()
        {
            MainViewModel.SwitchView(new MyStandardTourRequestsViewModel(MainViewModel, LoggedInUser, _dialogService));
        }

        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }
    }
}
