using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using MiniCore.Container.Tests.Common;
using MiniCore.Container.Tests.Common.Mocks;
using MiniCore.Container.Tests.Common.Helpers;

namespace MiniCore.Container.UnitTests
{
    [TestClass]
    public class ConstructorSelectorTests
    {
        [TestMethod]
        public void ShouldPickDefaultConstructorWhenNoneDeclared()
        {
            var expected = typeof(MockNoConstructor).GetConstructors().First().ToJSON();
            var actual = selector.Select(typeof(MockNoConstructor)).ToJSON();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldPickConstructorWithMostArguments()
        {
            var expected = typeof(MockMultipleConstructors).GetConstructors().First(f => f.GetParameters().Count() == 2).ToJSON();
            var actual = selector.Select(typeof(MockMultipleConstructors)).ToJSON();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowIfMultipleConstructorsWithSameNumberOfArguments()
        {
            selector.Select(typeof(MockSameNumberOfParamsConstructors));            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowIfDefaultCtorPrivateAndNoneDeclared()
        {            
            selector.Select(typeof(MockPrivateConstructor));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowWhenTypeNull()
        {
            selector.Select(null);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            selector = new ConstructorSelector();
        }

        private IConstructorSelector selector;
    }
}
