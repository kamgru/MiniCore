using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MiniCore.Container
{
    public class MiniCoreContainer : IContainer
    {
        private List<RegisteredPair> _registry = new List<RegisteredPair>();
        private IConstructorSelector _constructorSelector;
        public IEnumerable<RegisteredPair> Registry
        {
            get
            {
                return _registry.AsEnumerable();
            }
        }

        public MiniCoreContainer(IConstructorSelector constructorSelector)
        {
            _constructorSelector = constructorSelector;
        }

        public MiniCoreContainer() : this(new ConstructorSelector()) { }

        public void Register(Type from, Type to)
        {
            RegisterCheck(from);

            var register = new RegisteredPair(from, to);
            _registry.Add(register);
        }

        public object Resolve(Type type)
        {
            ResolveCheck(type);

            var to = Registry.First(f => f.From == type).To;
            var ctor = _constructorSelector.Select(to);
            var parameters = new List<object>();
            foreach (var p in ctor.GetParameters())
            {
                parameters.Add(Resolve(p.ParameterType));
            }
            return ctor.Invoke(parameters.ToArray());
            
        }

        private void ResolveCheck(Type type)
        {
            var from = Registry.FirstOrDefault(f => f.From == type);
            if (from == null)
            {
                throw new ArgumentException($"Type {type.ToString()} not registered");
            }
        }

        private void RegisterCheck(Type from)
        {
            if (from.GetTypeInfo().IsPrimitive)
            {
                throw new ArgumentException("Can't register primitive type");
            }

            if (Registry.Any(a => a.From == from))
            {
                throw new ArgumentException($"Multiple registrations of type {from.ToString()}");
            }
        }

        public void RegisterInstance(Type type, object instance)
        {
            RegisterCheck(type);

            var register = new RegisteredPair();
            register.From = type;
            register.Instance = instance;
            _registry.Add(register);
        }
    }
}
