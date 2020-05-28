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
        public StationDTO SelectedStation
        {
            get;
            set;
        }
        public int SelectedTrainId
        {
            get;
            set;
        }
        public TrainDTO SelectedTrain
        {
            get;
            set;
        }
        public int SelectedVanId
        {
            get;
            set;
        }
        public VanDTO SelectedVan
        {
            get;
            set;
        }
        public int SelectedSeatId
        {
            get;
            set;
        }
        public SeatDTO SelectedSeat
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
        public PassangerDTO Passanger { get; set; }

        public void LoadStations()
        {

            stationService = new StationService();
            ObservableCollection<StationDTO> stations = new ObservableCollection<StationDTO>();
            foreach (StationDTO station in stationService.GetAll().Data.ToList<StationDTO>()) stations.Add(station);

            Stations = stations;
        }
        public void RefreshTrains()
        {

            trainService = new TrainService();
            ObservableCollection<TrainDTO> trains = new ObservableCollection<TrainDTO>();
            foreach (TrainDTO train in trainService.GetAll().Data.ToList<TrainDTO>())
            {
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

            passangerService.Save();    

            Passanger = passanger;
            OnPropertyChanged(nameof(Passanger));
        }

        public void RefreshTickets()
        {
            stationService = new StationService();
            trainService = new TrainService();
            vanService = new VanService();
            seatService = new SeatService();

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
                Price = price,
                PassangerId = Passanger.Id
            };

            SelectedStation = stationService.Get(SelectedStationId).Data;
            SelectedTrain = trainService.Get(SelectedTrainId).Data;
            SelectedVan = vanService.Get(SelectedVanId).Data;
            SelectedSeat = seatService.Get(SelectedSeatId).Data;

            ticketService.Add(ticket);

            Ticket = ticket;
            OnPropertyChanged(nameof(SelectedStation));
            OnPropertyChanged(nameof(SelectedTrain));
            OnPropertyChanged(nameof(SelectedVan));
            OnPropertyChanged(nameof(SelectedSeat));
            OnPropertyChanged(nameof(Ticket));
            OnPropertyChanged(nameof(Stations));
        }
    }
}
