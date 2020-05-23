using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities;

namespace ReposirotyAPI.Data
{
    public class ReposirotyAPIContext : DbContext
    {
        public ReposirotyAPIContext (DbContextOptions<ReposirotyAPIContext> options)
        : base(options)
        {
        }

        public DbSet<Entities.Seat> Seat { get; set; }
        public DbSet<Entities.Train> Train { get; set; }
        public DbSet<Entities.Ticket> Ticket { get; set; }
        public DbSet<Entities.Passanger> Passanger { get; set; }
        public DbSet<Entities.Station> Station { get; set; }
        public DbSet<Entities.Van> Van { get; set; }
        public DbSet<Entities.ClassPropereties> ClassPropereties { get; set; }
        public DbSet<Entities.RoutePropereties> RoutePropereties { get; set; }
    }
}
