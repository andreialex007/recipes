using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RecipesSystem.Common
{
    public class WebApiException : Exception
    {
        public WebApiException()
        {
        }

        protected WebApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public WebApiException(string message) : base(message)
        {
        }

        public WebApiException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
