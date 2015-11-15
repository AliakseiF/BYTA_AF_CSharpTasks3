using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPark
{
        [Serializable]
        public class EmptyListException : Exception
        {

            public EmptyListException(string message) : base(message)
            {
            }

            public EmptyListException(string message, Exception inner) : base(message, inner)
            {
            }
    }
}
