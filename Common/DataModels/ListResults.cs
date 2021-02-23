using System.Collections.Generic;

namespace Common.DataModels
{
    public class ListResults<T>
    {
        public ListResults() { }

        public IEnumerable<T> Results { get; set; }
        public int TotalCount { get; set; }
    }
}
