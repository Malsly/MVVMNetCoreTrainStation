using DAl.Impl.EFCore;
using Entities;
using ReposirotyAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Impl.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private readonly ReposirotyAPIContext Context;
        private SeatRepository seatRepository;
        private VanRepository vanRepository;
        private TrainRepository trainRepository;
        private StationRepository stationRepository;
        private TicketRepository ticketRepository;
        private RouteProperetiesRepository routeProperetiesRepository;
        private ClassProperetiesRepository classProperetiesRepository;
        private PassangerRepository passangerRepository;


        public UnitOfWork(ReposirotyAPIContext context)
        {
            Context = context;
        }

        public SeatRepository SeatRepository
        {
            get
            {

                if (this.seatRepository == null)
                {
                    this.seatRepository = new SeatRepository(Context);
                }
                return seatRepository;
            }
        }
        public VanRepository VanRepository
        {
            get
            {

                if (this.vanRepository == null)
                {
                    this.vanRepository = new VanRepository(Context);
                }
                return vanRepository;
            }
        }
        public TrainRepository TrainRepository
        {
            get
            {

                if (this.trainRepository == null)
                {
                    this.trainRepository = new TrainRepository(Context);
                }
                return trainRepository;
            }
        }
        public StationRepository StationRepository
        {
            get
            {

                if (this.stationRepository == null)
                {
                    this.stationRepository = new StationRepository(Context);
                }
                return stationRepository;
            }
        }
        public TicketRepository TicketRepository
        {
            get
            {

                if (this.ticketRepository == null)
                {
                    this.ticketRepository = new TicketRepository(Context);
                }
                return ticketRepository;
            }
        }
        public RouteProperetiesRepository RouteProperetiesRepository
        {
            get
            {

                if (this.routeProperetiesRepository == null)
                {
                    this.routeProperetiesRepository = new RouteProperetiesRepository(Context);
                }
                return routeProperetiesRepository;
            }
        }
        public ClassProperetiesRepository ClassProperetiesRepository
        {
            get
            {

                if (this.classProperetiesRepository == null)
                {
                    this.classProperetiesRepository = new ClassProperetiesRepository(Context);
                }
                return classProperetiesRepository;
            }
        }
        public PassangerRepository PassangerRepository
        {
            get
            {

                if (this.passangerRepository == null)
                {
                    this.passangerRepository = new PassangerRepository(Context);
                }
                return passangerRepository;
            }
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
