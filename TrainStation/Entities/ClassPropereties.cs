using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ClassPropereties : IEntity
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public int Price { get; set; }
    }
}
