using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace MiniCore.Container.Wcf
{
    public class MiniCoreInstanceProviderBehaviour : IServiceBehavior
    {
        private readonly IContainer _container;

        public MiniCoreInstanceProviderBehaviour(IContainer container)
        {
            _container = container;
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var channelDispatcherBase in serviceHostBase.ChannelDispatchers)
            {
                var channelDispatcher = channelDispatcherBase as ChannelDispatcher;
                if (channelDispatcher != null)
                {
                    channelDispatcher.Endpoints.ToList().ForEach(
                        f => f.DispatchRuntime.InstanceProvider = new MiniCoreInstanceProvider(_container));
                }
            }
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters) { }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase) { }
    }
}
