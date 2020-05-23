using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Ticket : IEntity
    {
        public int Id { get; set; }
        public Passanger Passanger { get; set; }
        public int Price { get; set; }
        public Van Van { get; set; }
        public Train Train { get; set; }
        public Seat Seat { get; set; }
        public RoutePropereties RoutePropereties { get; set; }
    }
}
