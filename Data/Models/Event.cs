using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Event : IIdentifiable<Guid>, ITrackable
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid YoteId { get; set; }
        [Required]
        public Guid MeetId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Type { get; set; }
        [Required]
        [MaxLength(20)]
        public string Result { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
    }
}
