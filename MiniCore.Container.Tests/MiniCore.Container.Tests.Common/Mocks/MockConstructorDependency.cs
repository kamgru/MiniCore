using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCore.Container.Tests.Common.Mocks
{
    public class MockConstructorDependency 
    {
        public MockConstructorDependency(IDependency dependency) { }

        private MockConstructorDependency() { }
    }
}
