using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Train : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PlaceDeparture { get; set; }
        public string PlaceArrival { get; set; }
        [Required]
        public int StationId { get; set; }
        [ForeignKey(nameof(StationId))]
        public Station Station { get; set; }
        public List<RoutePropereties> RoutePropereties { get; set; }
        public List<Van> Vans { get; set; }
    }
}
