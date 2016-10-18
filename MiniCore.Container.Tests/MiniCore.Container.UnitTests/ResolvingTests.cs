using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniCore.Container;
using MiniCore.Container.Tests.Common.Mocks;

namespace MiniCore.Container.UnitTests
{
    [TestClass]
    public class ResolvingTests : ContainerTestsBase
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowIfTypeNotRegistered()
        {
            container.Resolve(typeof(IMock));
        }

        [TestMethod]
        public void ShouldResolveParameterlessConstructorObject()
        {
            container.Register(typeof(IMock), typeof(MockPoco));
            Assert.IsInstanceOfType(container.Resolve(typeof(IMock)), typeof(MockPoco));
        }

        [TestMethod]
        public void ShouldResolveObjectWithRegisteredDependency()
        {
            container.Register(typeof(IMock), typeof(MockConstructorDependency));
            container.Register(typeof(IDependency), typeof(MockDependency));

            Assert.IsNotNull(container.Resolve(typeof(IMock)));
        }

        [TestMethod]
        public void ShouldResolveObjectInstance()
        {
            var instance = new MockPoco();
            container.RegisterInstance(typeof(IMock), instance);
            Assert.IsNotNull(container.Resolve(typeof(IMock)));
        }
    }
}
