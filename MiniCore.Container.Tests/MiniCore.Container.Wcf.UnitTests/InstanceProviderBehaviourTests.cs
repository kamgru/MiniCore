using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniCore.Container.Tests.Common.Mocks;
using MiniCore.Container.Wcf.UnitTests.Mocks;

namespace MiniCore.Container.Wcf.UnitTests
{
    [TestClass]
    public class InstanceProviderBehaviourTests
    {
        [TestMethod]
        public void ShouldApplyBehaviour()
        {
            var host = new MockServiceHost(typeof(MockPoco));
            var dispatcher = new MockChannelDispatcher();
            dispatcher.Endpoints.Add(new EndpointDispatcher(new EndpointAddress("net.tcp://mock"), "", ""));
            host.ChannelDispatchers.Add(dispatcher);

            var container = new MiniCoreContainer();
            var behaviour = new MiniCoreInstanceProviderBehaviour(new MiniCoreInstanceProvider(container));

            behaviour.ApplyDispatchBehavior(new ServiceDescription(), host);

            var endpoints = new List<EndpointDispatcher>();
            foreach(var channelDispatcher in host.ChannelDispatchers)
            {
                endpoints.AddRange((channelDispatcher as MockChannelDispatcher).Endpoints);
            }

            CollectionAssert.AllItemsAreInstancesOfType(endpoints.Select(s => s.DispatchRuntime.InstanceProvider).ToList(), typeof(MiniCoreInstanceProvider));
        }
    }
}
