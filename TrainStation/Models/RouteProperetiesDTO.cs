
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class RouteProperetiesDTO 
    {
        public int Id { get; set; }
        public int Price {get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }
        public int TrainId { get; set; }

    }
}
