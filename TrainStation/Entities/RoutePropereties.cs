using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class RoutePropereties : IEntity
    {
        public int Id { get; set; }
        public int Price {get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }
    }
}
