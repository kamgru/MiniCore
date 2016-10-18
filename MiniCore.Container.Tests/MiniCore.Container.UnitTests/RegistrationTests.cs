using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniCore.Container;
using MiniCore.Container.Tests.Common.Mocks;

namespace MiniCore.Container.UnitTests
{
    [TestClass]
    public class RegistrationTests : ContainerTestsBase
    {
        [TestMethod]
        public void ShouldRegisterTypePair()
        {
            container.Register(typeof(IMock), typeof(MockNoConstructor));
            var registered = container.Registry.First(f => f.From == typeof(IMock));
            Assert.AreSame(typeof(MockNoConstructor), registered.To);
        }

        [TestMethod]
        public void ShouldRegisterInstance()
        {
            var instance = new MockNoConstructor();
            container.RegisterInstance(typeof(IMock), instance);
            var registered = container.Registry.First(f => f.From == typeof(IMock));
            Assert.AreSame(instance, registered.Instance);
        }

        [TestMethod]
        public void ShouldMapFromTypeWhenToIsNull()
        {
            container.Register(typeof(MockNoConstructor), null);
            var registered = container.Registry.First(f => f.From == typeof(MockNoConstructor));
            Assert.AreSame(typeof(MockNoConstructor), registered.To);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowWhenFromNull()
        {
            container.Register(null, null);
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowIfMultipleRegistrationsOfSameType()
        {
            container.Register(typeof(IMock), typeof(MockNoConstructor));
            container.Register(typeof(IMock), typeof(MockPrivateConstructor));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowIfRegisteringPrimitiveType()
        {
            container.Register(typeof(int), null);
        }

    }
}
