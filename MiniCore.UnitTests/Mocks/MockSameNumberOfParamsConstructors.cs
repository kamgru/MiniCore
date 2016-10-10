using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCore.UnitTests.Mocks
{
    public class MockSameNumberOfParamsConstructors
    {
        public MockSameNumberOfParamsConstructors(string s, int t) { }
        public MockSameNumberOfParamsConstructors(int i, string s) { }
    }
}
