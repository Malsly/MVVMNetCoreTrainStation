using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Ticket : IEntity
    {
        public int Id { get; set; }
        public int Price { get; set; }
        [Required]
        public int PassangerId { get; set; }
        [Required]
        public int VanId { get; set; }
        [Required]
        public int TrainId { get; set; }
        [Required]
        public int SeatId { get; set; }
        [ForeignKey(nameof(PassangerId))]
        public Passanger Passanger { get; set; }
        [ForeignKey(nameof(VanId))]
        public Van Van { get; set; }
        [ForeignKey(nameof(TrainId))]
        public Train Train { get; set; }
        [ForeignKey(nameof(SeatId))]
        public Seat Seat { get; set; }
    }
}
