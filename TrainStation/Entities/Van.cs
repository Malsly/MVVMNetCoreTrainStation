using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Van : IEntity
    {
        public int Id { get; set; }
        public List<Seat> Seats { get; set; }
        [Required]
        public int ClassProperetiesId { get; set; }

        [ForeignKey(nameof(ClassProperetiesId))]
        public ClassPropereties ClassPropereties { get; set; }
        public int Number { get; set; }
    }
}
