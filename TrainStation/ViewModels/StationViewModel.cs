using BL.Abstract;
using BL.Impl;
using Entities;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ViewModels
{
    public class StationViewModel
    {
        IStationService stationService;
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
            stationService = new StationService();
            ObservableCollection<StationDTO> stations = new ObservableCollection<StationDTO>();
            
            foreach (StationDTO station in stationService.GetAll().Data.ToList<StationDTO>()) stations.Add(station);

            Stations = stations;
        }
    }
}
