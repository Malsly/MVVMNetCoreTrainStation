
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class TrainDTO 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlaceDeparture { get; set; }
        public string PlaceArrival { get; set; }
        public List<RouteProperetiesDTO> RoutePropereties { get; set; }
    }
}
