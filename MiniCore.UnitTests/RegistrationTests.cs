using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniCore.UnitTests.Mocks;

namespace MiniCore.UnitTests
{
    [TestClass]
    public class RegistrationTests
    {
        [TestMethod]
        public void ShouldRegisterTypePair()
        {
            container.Register(typeof(IMock), typeof(MockNoConstructor));
            var registered = container.Registry.First(f => f.From == typeof(IMock));
            Assert.AreSame(typeof(MockNoConstructor), registered.To);
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

        [TestInitialize]
        public void TestInitialize()
        {
            container = new MiniCoreContainer();
        }

        private IContainer container;
    }
}
