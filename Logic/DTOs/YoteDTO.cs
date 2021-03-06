﻿using Data.Models;
using System;
using System.Collections.Generic;

namespace Logic.DTOs
{
    public class YoteDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Height { get; set; }
        public int? Weight { get; set; }
        public string Year { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? YearGraduated { get; set; }
        public List<Event> Events { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string ModifiedBy { get; set; }
    }
}
