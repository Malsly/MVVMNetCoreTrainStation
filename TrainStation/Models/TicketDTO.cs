
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class TicketDTO 
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public PassangerDTO Passanger { get; set; }
        public VanDTO Van { get; set; }
        public TrainDTO Train { get; set; }
        public SeatDTO Seat { get; set; }
        public RouteProperetiesDTO RoutePropereties { get; set; }
    }
}
