
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class SeatDTO 
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Type { get; set; }
        public Boolean IsOccupied { get; set; }
        public int VanId { get; set; }
    }
}
