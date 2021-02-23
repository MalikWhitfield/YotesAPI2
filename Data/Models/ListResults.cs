using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class ListResults<T>
    {
        public ListResults() { }
        public IEnumerable<T> Results { get; set; }
        public int TotalCount { get; set; }
    }
}
