using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IIdentifiable<K>
    {
        K Id { get; set; }
    }
}
