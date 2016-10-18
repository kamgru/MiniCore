using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCore.Container.Tests.Common.Mocks
{
    public class MockSameNumberOfParamsConstructors : IMock
    {
        public MockSameNumberOfParamsConstructors(string s, int t) { }
        public MockSameNumberOfParamsConstructors(int i, string s) { }
    }
}
