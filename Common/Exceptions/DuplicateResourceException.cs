using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class DuplicateResourceException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public DuplicateResourceException(string message) : base(message)
        {

        }
    }
}
