﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniCore.Container;
using MiniCore.UnitTests.Mocks;

namespace MiniCore.UnitTests
{
    [TestClass]
    public class ResolvingTests
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
            container.Register(typeof(IMock), typeof(MockNoConstructor));
            Assert.IsInstanceOfType(container.Resolve(typeof(IMock)), typeof(MockNoConstructor));
        }

        [TestMethod]
        public void ShouldResolveObjectWithRegisteredDependency()
        {
            container.Register(typeof(IMock), typeof(MockConstructorDependency));
            container.Register(typeof(IDependency), typeof(MockDependency));

            Assert.IsNotNull(container.Resolve(typeof(IMock)));
        }

        [TestInitialize]
        public void TestInitialize()
        {
            container = new MiniCoreContainer();
        }

        private IContainer container;
    }
}
