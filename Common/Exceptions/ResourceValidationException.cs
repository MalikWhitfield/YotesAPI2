using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Exceptions
{
    public class ResourceValidationException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ResourceValidationException(string message) : base(message)
        {

        }
    }
}
