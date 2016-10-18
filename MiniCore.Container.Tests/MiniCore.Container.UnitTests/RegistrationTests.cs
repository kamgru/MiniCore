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
            container.Register(typeof(IMock), typeof(MockPoco));
            var registered = container.Registry.First(f => f.From == typeof(IMock));
            Assert.AreSame(typeof(MockPoco), registered.To);
        }

        [TestMethod]
        public void ShouldRegisterInstance()
        {
            var instance = new MockPoco();
            container.RegisterInstance(typeof(IMock), instance);
            var registered = container.Registry.First(f => f.From == typeof(IMock));
            Assert.AreSame(instance, registered.Instance);
        }

        [TestMethod]
        public void ShouldMapFromTypeWhenToIsNull()
        {
            container.Register(typeof(MockPoco), null);
            var registered = container.Registry.First(f => f.From == typeof(MockPoco));
            Assert.AreSame(typeof(MockPoco), registered.To);
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
            container.Register(typeof(IMock), typeof(MockPoco));
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
