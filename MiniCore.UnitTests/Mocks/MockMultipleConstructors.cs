﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniCore.UnitTests.Mocks
{
    public class MockMultipleConstructors
    {
        public MockMultipleConstructors() { }

        public MockMultipleConstructors(string s) { }

        public MockMultipleConstructors(string s, int i) { }

    }
}