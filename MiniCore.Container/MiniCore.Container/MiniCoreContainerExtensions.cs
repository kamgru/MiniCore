using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCore.Container
{
    public static class MiniCoreContainerExtensions
    {
        public static void Register<T,V>(this IContainer container)
        {
            container.Register(typeof(T), typeof(V));
        }

        public static void Register<T>(this IContainer container)
        {
            container.Register(typeof(T), null);
        }

        public static void Register<T>(this IContainer container, T instance)
        {
            container.RegisterInstance(typeof(T), instance);
        }

        public static T Resolve<T>(this IContainer container)
        {
            return (T)container.Resolve(typeof(T));
        }
    }
}
