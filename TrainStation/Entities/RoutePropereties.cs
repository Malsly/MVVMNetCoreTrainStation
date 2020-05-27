using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class RoutePropereties : IEntity
    {
        public int Id { get; set; }
        public int Price {get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public int TrainId { get; set; }
        [ForeignKey(nameof(TrainId))]
        public Train Train { get; set; }
    }
}
