using BL.Abstract;
using BL.Impl;
using Entities;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ViewModels.Impl
{
    public class StationViewModel : INotifyPropertyChanged
    {
        public string TestForBind { get; set; }

        IStationService stationService;
        ITrainService trainService;
        IVanService vanService;
        ISeatService seatService;
        ITicketService ticketService;
        IPassangerService passangerService;
        IRouteProperetiesService routeProperetiesService;
        IClassProperetiesService classProperetiesService;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

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
        public int SelectedStationId
        {
            get;
            set;
        }
        public int SelectedTrainId
        {
            get;
            set;
        }
        public int SelectedVanId
        {
            get;
            set;
        }
        public int SelectedSeatId
        {
            get;
            set;
        }
        public string PassangerName
        {
            get;
            set;
        }
        public string PassangerEmail
        {
            get;
            set;
        }
        public string PassangerTelephone
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
        public PassangerDTO Passanger { get; set; }

        public void LoadStations()
        {
            
            stationService = new StationService();
            ObservableCollection<StationDTO> stations = new ObservableCollection<StationDTO>();
            foreach (StationDTO station in stationService.GetAll().Data.ToList<StationDTO>()) stations.Add(station);

            Stations = stations;
            //OnPropertyChanged(nameof(Stations));
        }
        public void RefreshTrains()
        {
            
            trainService = new TrainService();
            ObservableCollection<TrainDTO> trains = new ObservableCollection<TrainDTO>();
            foreach(TrainDTO train in trainService.GetAll().Data.ToList<TrainDTO>()) {
                if (train.StationId == SelectedStationId) 
                {
                    trains.Add(train);
                }
            }

            Trains = trains;
            OnPropertyChanged(nameof(Trains));
        }
        public void RefreshVans()
        {

            vanService = new VanService();
            ObservableCollection<VanDTO> vans = new ObservableCollection<VanDTO>();
            foreach (VanDTO van in vanService.GetAll().Data.ToList<VanDTO>())
            {
                if (van.TrainId == SelectedTrainId)
                {
                    vans.Add(van);
                }
            }

            Vans = vans;
            OnPropertyChanged(nameof(Vans));
        }
        public void RefreshSeats()
        {

            seatService = new SeatService();
            ObservableCollection<SeatDTO> seats = new ObservableCollection<SeatDTO>();
            foreach (SeatDTO seat in seatService.GetAll().Data.ToList<SeatDTO>())
            {
                if (seat.VanId == SelectedVanId)
                {
                    seats.Add(seat);
                }
            }

            Seats = seats;
            OnPropertyChanged(nameof(Seats));
        }

        public void RefreshPassangers()
        {

            passangerService = new PassangerService();

            PassangerDTO passanger = new PassangerDTO()
            {
                Name = PassangerName,
                Email = PassangerEmail,
                Telephone = PassangerTelephone
            };

            passangerService.Add(passanger);

            Passanger = passanger;
            OnPropertyChanged(nameof(Passanger));
        }

        public void RefreshTickets()
        {
            classProperetiesService = new ClassProperetiesService();
            ticketService = new TicketService();
            int price = trainService.Get(SelectedTrainId).Data.RoutePropereties.Last().Price;
            VanDTO neededVan = vanService.Get(SelectedVanId).Data;

            int idClass = neededVan.ClassProperetiesId;
            price += classProperetiesService.Get(idClass).Data.Price;

            


            
            TicketDTO ticket = new TicketDTO()
            {
                VanId = SelectedVanId,
                SeatId = SelectedSeatId,
                TrainId = SelectedTrainId,
                StationId = SelectedStationId,
                Price = price,
                PassangerId = Passanger.Id
            };


            ticketService.Add(ticket);

            Ticket = ticket;
            OnPropertyChanged(nameof(Ticket));
        }
    }
}
