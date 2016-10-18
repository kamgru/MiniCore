using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniCore.Container.Tests.Common.Mocks;

namespace MiniCore.Container.UnitTests
{
    [TestClass]
    public class ExtensionsTests : ContainerTestsBase
    {
        [TestMethod]
        public void ShouldRegisterGeneric()
        {
            container.Register<IMock, MockNoConstructor>();
            var registered = container.Registry.First(f => f.From == typeof(IMock));
            Assert.AreSame(typeof(MockNoConstructor), registered.To);
        }

        [TestMethod]
        public void ShouldMapFromToGeneric()
        {
            container.Register<MockNoConstructor>();
            var registered = container.Registry.First(f => f.From == typeof(MockNoConstructor));
            Assert.AreSame(typeof(MockNoConstructor), registered.To);
        }

        [TestMethod]
        public void ShouldRegisterInstanceGeneric()
        {
            var instance = new MockNoConstructor();
            container.Register<IMock>(instance);
            var registered = container.Registry.First(f => f.From == typeof(IMock));
            Assert.AreSame(instance, registered.Instance);
        }

        [TestMethod]
        public void ShouldResolveGeneric()
        {
            var instance = new MockNoConstructor();
            container.Register<IMock>(instance);
            var resolved = container.Resolve<IMock>();

            Assert.AreSame(instance, resolved);
        }
    }
}
