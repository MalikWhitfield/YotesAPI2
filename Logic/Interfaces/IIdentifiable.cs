using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Interfaces
{
    public interface IIdentifiable<K>
    {
        K Id { get; set; }
    }
}
