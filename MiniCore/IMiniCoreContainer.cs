using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCore
{
    public interface IMiniCoreContainer
    {
        void Register<T, V>();
        void Register(Type from, Type to);
        T Resolve<T>();
        object Resolve(Type type);
    }
}
