using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TaxiPark
{
        [Serializable]
        public class NoColorException : Exception
        {
            private string _noColorName;
            public string NoColorName
            {
                get { return _noColorName; }
                set { _noColorName = value; }
            }

            public NoColorException(string message) : base(message)
            {
            }

            public NoColorException(string message, Exception inner) : base(message, inner)
            {
            }

            protected NoColorException(
                SerializationInfo info,
                StreamingContext context) : base(info, context)
            {
            if (info != null)
            {
                this._noColorName = info.GetString("NoColorName");
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("NoColorName", this.NoColorName);
        }
    }
}
