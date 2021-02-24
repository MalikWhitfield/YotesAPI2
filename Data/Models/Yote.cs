using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Yote : IIdentifiable<Guid>, ITrackable
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Bio { get; set; }
        public string Image { get; set; }
        [Required]
        [MaxLength(10)]
        public string Height { get; set; }
        public int? Weight { get; set; }
        [Required]
        [MaxLength(20)]
        public string Year { get; set; }
        [MaxLength(30)]
        public string EventGroup { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? YearGraduated { get; set; }
        public List<Event> Events { get; set; }
        public DateTime CreatedAt { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
    }
}
