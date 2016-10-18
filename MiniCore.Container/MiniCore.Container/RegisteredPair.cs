using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCore.Container
{
    public class RegisteredPair
    {
        public Type From { get; internal set; }
        public Type To { get; private set; }
        public object Instance { get; internal set; }

        public RegisteredPair(Type from, Type to)
        {
            if (from == null)
            {
                throw new ArgumentNullException(nameof(from));
            }
            From = from;
            To = to == null ? from : to;
        }

        public RegisteredPair() { }
    }
}
