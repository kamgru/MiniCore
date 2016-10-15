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
        public void PicksDefaultConstructorIfNoneDeclared()
        {
            var expected = typeof(Mocks.MockNoConstructor).GetConstructors().First().ToJSON();
            var actual = selector.Select(typeof(Mocks.MockNoConstructor)).ToJSON();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PicksConstructorWithMostArguments()
        {
            var expected = typeof(Mocks.MockMultipleConstructors).GetConstructors().First(f => f.GetParameters().Count() == 2).ToJSON();
            var actual = selector.Select(typeof(Mocks.MockMultipleConstructors)).ToJSON();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsIfMultipleConstructorsWithSameNumberOfArguments()
        {
            selector.Select(typeof(Mocks.MockSameNumberOfParamsConstructors));            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsIfDefaultCtorPrivateAndNoneDeclared()
        {            
            selector.Select(typeof(Mocks.MockPrivateConstructor));
        }

        [TestInitialize]
        public void TestInitialize()
        {
            selector = new ConstructorSelector();
        }

        private IConstructorSelector selector;
    }
}
