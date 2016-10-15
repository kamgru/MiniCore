using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCore
{
    public class MiniCoreContainer : IContainer
    {
        private List<RegisteredPair> _registry = new List<RegisteredPair>();
        public IEnumerable<RegisteredPair> Registry
        {
            get
            {
                return _registry.AsEnumerable();
            }
        }

        public void Register(Type from, Type to)
        {
            if (Registry.Any(a => a.From == from))
            {
                throw new ArgumentException($"Multiple registrations of type {from.ToString()}");
            }

            var register = new RegisteredPair(from, to);
            _registry.Add(register);
        }

        public object Resolve(Type type)
        {
            Check(type);

            var to = Registry.First(f => f.From == type).To;
            return Activator.CreateInstance(to);
            
        }

        private void Check(Type type)
        {
            var from = Registry.FirstOrDefault(f => f.From == type);
            if (from == null)
            {
                throw new ArgumentException($"Type {type.ToString()} not registered");
            }
        }
    }
}
