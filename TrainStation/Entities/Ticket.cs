using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Ticket : IEntity
    {
        public int Id { get; set; }
        public Passanger PassangerId { get; set; }
        public int Price { get; set; }
        public Van VanId { get; set; }
        public Train TrainId { get; set; }
        public Seat SeatId { get; set; }
        public RoutePropereties RouteProperetiesId { get; set; }
    }
}
