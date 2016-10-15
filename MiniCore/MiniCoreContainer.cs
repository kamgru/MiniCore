using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCore
{
    public class MiniCoreContainer : IMiniCoreContainer
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
            var register = new RegisteredPair(from, to);
            _registry.Add(register);
        }

        public object Resolve(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
