using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCore
{
    public interface IMiniCoreContainer
    {
        void Register(Type from, Type to);
        object Resolve(Type type);
        IEnumerable<RegisteredPair> Registry { get; }
    }
}
