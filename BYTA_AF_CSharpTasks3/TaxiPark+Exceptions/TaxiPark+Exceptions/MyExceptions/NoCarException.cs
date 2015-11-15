using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPark
{
        [Serializable]
        public class NoCarException : Exception
        {

            public NoCarException(string message) : base(message)
            {
            }

            public NoCarException(string message, Exception inner) : base(message, inner)
            {
            }
    }
}
