using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Train : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlaceDeparture { get; set; }
        public string PlaceArrival { get; set; }
        public List<RoutePropereties> RoutePropereties { get; set; }
        public List<Van> Vans { get; set; }
    }
}
