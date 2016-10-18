using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCore.Container.UnitTests.Mocks
{
    public class MockPrivateConstructor : IMock
    {
        private MockPrivateConstructor() { }
    }
}
