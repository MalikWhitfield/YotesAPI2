﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.DTOs
{
    public class UpdateYoteDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Height { get; set; }
        public int? Weight { get; set; }
        public string Year { get; set; }
        public string EventGroup { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? YearGraduated { get; set; }
    }
}
