using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public interface IIdentifiable<K>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        K Id { get; set; }
    }
}
