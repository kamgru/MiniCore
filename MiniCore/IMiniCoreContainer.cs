using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCore.Container
{
    public interface IContainer
    {
        void Register(Type from, Type to);
        object Resolve(Type type);
        IEnumerable<RegisteredPair> Registry { get; }

        void RegisterInstance(Type type, object instance);
    }
}
