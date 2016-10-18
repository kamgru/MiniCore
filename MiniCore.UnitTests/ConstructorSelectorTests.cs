using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using MiniCore.Container.UnitTests.Helpers;

namespace MiniCore.Container.UnitTests
{
    [TestClass]
    public class ConstructorSelectorTests
    {
        [TestMethod]
        public void ShouldPickDefaultConstructorWhenNoneDeclared()
        {
            var expected = typeof(Mocks.MockNoConstructor).GetConstructors().First().ToJSON();
            var actual = selector.Select(typeof(Mocks.MockNoConstructor)).ToJSON();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ShouldPickConstructorWithMostArguments()
        {
            var expected = typeof(Mocks.MockMultipleConstructors).GetConstructors().First(f => f.GetParameters().Count() == 2).ToJSON();
            var actual = selector.Select(typeof(Mocks.MockMultipleConstructors)).ToJSON();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowIfMultipleConstructorsWithSameNumberOfArguments()
        {
            selector.Select(typeof(Mocks.MockSameNumberOfParamsConstructors));            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowIfDefaultCtorPrivateAndNoneDeclared()
        {            
            selector.Select(typeof(Mocks.MockPrivateConstructor));
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
