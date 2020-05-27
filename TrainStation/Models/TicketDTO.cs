
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class TicketDTO 
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int PassangerId { get; set; }
        public int VanId { get; set; }
        public int TrainId { get; set; }
        public int SeatId { get; set; }
        public int RouteProperetiesId { get; set; }
    }
}
