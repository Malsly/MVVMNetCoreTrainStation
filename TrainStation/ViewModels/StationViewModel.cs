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
        ITrainService trainService;
        IVanService vanService;
        ISeatService seatService;
        ITicketService ticketService;
        IPassangerService passangerService;
        IRouteProperetiesService routeProperetiesService;
        IClassProperetiesService classProperetiesService;
        public ObservableCollection<StationDTO> Stations
        {
            get;
            set;
        }
        public ObservableCollection<TrainDTO> Trains
        {
            get;
            set;
        }
        public ObservableCollection<VanDTO> Vans
        {
            get;
            set;
        }
        public ObservableCollection<SeatDTO> Seats
        {
            get;
            set;
        }
        public ObservableCollection<RouteProperetiesDTO> Routes
        {
            get;
            set;
        }
        public ObservableCollection<ClassProperetiesDTO> Classes
        {
            get;
            set;
        }
        public StationDTO SelectedStation
        {
            get;
            set;
        }
        public TrainDTO SelectedTrain
        {
            get;
            set;
        }
        public VanDTO SelectedVan
        {
            get;
            set;
        }
        public SeatDTO SelectedSeat
        {
            get;
            set;
        }
        public PassangerDTO Passanger
        {
            get;
            set;
        }
        public TicketDTO Ticket
        {
            get;
            set;
        }
        public RouteProperetiesDTO SelectedRoute
        {
            get;
            set;
        }

        public void LoadStations()
        {
            seatService = new SeatService();
            vanService = new VanService();
            trainService = new TrainService();            
            stationService = new StationService();
            trainService = new TrainService();
            
            ObservableCollection<StationDTO> stations = new ObservableCollection<StationDTO>();
            ObservableCollection<TrainDTO> trains = new ObservableCollection<TrainDTO>();
            ObservableCollection<VanDTO> vans = new ObservableCollection<VanDTO>();
            ObservableCollection<SeatDTO> seats = new ObservableCollection<SeatDTO>();

            foreach (SeatDTO seat in seatService.GetAll().Data.ToList<SeatDTO>()) seats.Add(seat);

            foreach (VanDTO van in vanService.GetAll().Data.ToList<VanDTO>()) vans.Add(van);

            foreach (TrainDTO train in trainService.GetAll().Data.ToList<TrainDTO>()) trains.Add(train);

            foreach (StationDTO station in stationService.GetAll().Data.ToList<StationDTO>()) stations.Add(station);

            


            Stations = stations;
            Trains = trains;
            Vans = vans;
            Seats = seats;
        }
    }
}
