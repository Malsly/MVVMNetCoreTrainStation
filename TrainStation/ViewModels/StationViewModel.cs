using BL.Impl;
using Entities;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ViewModels
{
    public class StationViewModel
    {

        public ObservableCollection<StationDTO> Stations
        {
            get;
            set;

        }
        public StationDTO SelectedStation
        {
            get;
            set;
        }

        public void LoadStations()
        {
            ObservableCollection<StationDTO> stations = new ObservableCollection<StationDTO>();

            var stationService = new StationService();

            foreach (StationDTO station in stationService.GetAll().Data.ToList<StationDTO>()) stations.Add(station);

            Stations = stations;
        }
    }
}
