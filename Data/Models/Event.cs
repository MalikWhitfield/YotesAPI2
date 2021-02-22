using Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Event : IIdentifiable<Guid>, ITrackable
    {
        public Guid Id { get; set; }
        public Guid MeetId { get; set; }
        public string Type { get; set; }
        public string Result { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
    }
}
