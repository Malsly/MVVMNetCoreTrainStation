
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class StationDTO 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TrainDTO> Trains { get; set; }
    }
}
