using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MiniCore.Container.UnitTests
{
    [TestClass]
    public class ContainerTestsBase
    {

        [TestInitialize]
        public void TestInitialize()
        {
            container = new MiniCoreContainer();
        }

        protected IContainer container;
    }
}
