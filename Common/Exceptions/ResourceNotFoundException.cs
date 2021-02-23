using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class ResourceNotFoundException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ResourceNotFoundException(string message) : base(message)
        {

        }
    }
}
