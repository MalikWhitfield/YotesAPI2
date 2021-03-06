﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface ITrackable
    {
        DateTime CreatedAt { get; set; }
        string CreatedBy { get; set; }
        DateTime ModifiedAt { get; set; }
        string ModifiedBy { get; set; }
    }
}
