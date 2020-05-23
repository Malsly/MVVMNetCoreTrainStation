using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Van : IEntity
    {
        public int Id { get; set; }
        public List<Seat> Seats { get; set; }
        public ClassPropereties ClassPropereties { get; set; }
        public int Number { get; set; }
    }
}
