using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Seat : IEntity
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Type { get; set; }
        public Boolean IsOccupied { get; set; }
        [Required]
        public int VanId { get; set; }
        [ForeignKey(nameof(VanId))]
        public Van Van { get; set; }
    }
}
