using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniCore.Container.Wcf.UnitTests.Mocks;

namespace MiniCore.Container.Wcf.UnitTests
{
    [TestClass]
    public class ServiceHostTests
    {
        [TestMethod]
        public void ShouldAddBehaviourToDescription()
        {
            var container = new MiniCoreContainer();
            var host = new MiniCoreServiceHost(container, typeof(MockService), new[] { new Uri("net.tcp://mock") });
            host.Open();
            host.Close();

            Assert.IsTrue(host.Description.Behaviors.Any(a => a.GetType() == typeof(MiniCoreInstanceProviderBehaviour)));
        }
    }
}
