using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Meet : IIdentifiable<Guid>, ITrackable
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(100)]
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
    }
}
