using DAl.Impl.EFCore;
using DAl.Impl.Repositories;
using Entities;
using ReposirotyAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAl.Impl.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private readonly ReposirotyAPIContext _context;
        private readonly GenericRepository<Seat> seatRepository;
        private readonly GenericRepository<Van> vanRepository;
        private readonly GenericRepository<Train> trainRepository;
        private readonly GenericRepository<Ticket> ticketRepository;
        private readonly GenericRepository<Station> stationRepository;
        private readonly GenericRepository<RoutePropereties> routeProperetiesRepository;
        private readonly GenericRepository<Passanger> passangerRepository;
        private readonly GenericRepository<ClassPropereties> classProperetiesRepository;

        public UnitOfWork()
        {
            _context = new ReposirotyAPIContext();
            seatRepository = new GenericRepository<Seat>(_context);
            vanRepository = new GenericRepository<Van>(_context);
            trainRepository = new GenericRepository<Train>(_context);
            ticketRepository = new GenericRepository<Ticket>(_context);
            stationRepository = new GenericRepository<Station>(_context);
            routeProperetiesRepository = new GenericRepository<RoutePropereties>(_context);
            classProperetiesRepository = new GenericRepository<ClassPropereties>(_context);
            passangerRepository = new GenericRepository<Passanger>(_context);
        }
        public GenericRepository<Passanger> Passangers
        {
            get
            {
                return passangerRepository;
            }
        }
        public GenericRepository<ClassPropereties> ClassPropereties
        {
            get
            {
                return classProperetiesRepository;
            }
        }
        public GenericRepository<RoutePropereties> RoutePropereties
        {
            get
            {
                return routeProperetiesRepository;
            }
        }
        public GenericRepository<Station> Stations
        {
            get
            {
                return stationRepository;
            }
        }
        public GenericRepository<Ticket> Tickets
        {
            get
            {
                return ticketRepository;
            }
        }
        public GenericRepository<Train> Trains
        {
            get
            {
                return trainRepository;
            }
        }
        public GenericRepository<Van> Vans
        {
            get
            {
                return vanRepository;
            }
        }

        public GenericRepository<Seat> Seats
        {
            get
            {
                return seatRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;


        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
