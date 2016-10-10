using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MiniCore
{
    public class MiniConstructorSelector : IConstructorSelector
    {
        public ConstructorInfo Select(Type type)
        {
            var ctors = type.GetConstructors().OrderByDescending(order => order.GetParameters().Length);

            if (ctors.Count() > 1)
            {
                if (ctors.First().GetParameters().Length == ctors.ElementAt(1).GetParameters().Length)
                {
                    throw new ArgumentException("Multiple similar constructors");
                }
            }

            var selectedCtor = ctors?.FirstOrDefault();

            if (selectedCtor == null)
            {
                throw new ArgumentException("No constructor found");
            }            

            return selectedCtor;
        }
    }
}
