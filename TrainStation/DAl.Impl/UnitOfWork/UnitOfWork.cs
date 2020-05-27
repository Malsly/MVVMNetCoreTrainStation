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
        private ReposirotyAPIContext context;
        private GenericRepository<Seat> seatRepository;

        public UnitOfWork(ReposirotyAPIContext context)
        {
            this.context = context;
        }

        public GenericRepository<Seat> SeatRepository
        {
            get
            {

                if (this.seatRepository == null)
                {
                    this.seatRepository = new GenericRepository<Seat>(context);
                }
                return seatRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
