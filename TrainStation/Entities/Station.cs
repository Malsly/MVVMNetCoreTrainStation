using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Station : IEntity
    {
        public int Id { get; set; }
        public List<Train> Trains { get; set; }
        public string Name { get; set; }
    }
}
