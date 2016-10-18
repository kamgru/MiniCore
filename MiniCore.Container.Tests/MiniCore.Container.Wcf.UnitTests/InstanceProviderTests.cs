using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniCore.Container;
using MiniCore.Container.Tests.Common.Mocks;
using MiniCore.Container.Wcf;
using MiniCore.Container.Wcf.UnitTests.Mocks;

namespace MiniCore.Container.Wcf.UnitTests
{
    [TestClass]
    public class InstanceProviderTests
    {
        [TestMethod]
        public void ShouldProvideInstance()
        {
            var container = new MiniCoreContainer();
            var instance = new MockPoco();
            container.Register(instance);

            var provider = new MiniCoreInstanceProvider(container);
            var context = new InstanceContext(new MockServiceHost(typeof(MockPoco)));

            var actual = provider.GetInstance(context);

            Assert.AreSame(instance, actual);
        }
    }
}
