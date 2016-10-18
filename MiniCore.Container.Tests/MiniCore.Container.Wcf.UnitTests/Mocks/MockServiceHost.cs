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

namespace MiniCore.Container.Wcf.UnitTests.Mocks
{
    public class MockServiceHost : ServiceHostBase
    {
        private readonly Type _serviceType;
        private readonly ServiceDescription _description;
        public MockServiceHost(Type serviceType) : base()
        {
            _serviceType = serviceType;
            _description = new ServiceDescription();
            _description.ServiceType = _serviceType;
            InitializeDescription(new UriSchemeKeyedCollection(new Uri[] { new Uri("net.tcp://mock") }));
        }


        protected override ServiceDescription CreateDescription(out IDictionary<string, ContractDescription> implementedContracts)
        {
            var contractDescription = new ContractDescription("MockContractDescription");
            implementedContracts = new Dictionary<string, ContractDescription>();
            implementedContracts.Add("MockContractDescription", contractDescription);            
            return _description;
        }
    }

    public class MockChannelDispatcher : ChannelDispatcher
    {
        public MockChannelDispatcher() : base(new MockListener())
        {
        }
    }

    public class MockListener : IChannelListener
    {
        public CommunicationState State
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Uri Uri
        {
            get
            {
                return new Uri("net.tcp://mock");
            }
        }

        public event EventHandler Closed;
        public event EventHandler Closing;
        public event EventHandler Faulted;
        public event EventHandler Opened;
        public event EventHandler Opening;

        public void Abort()
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginClose(AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginOpen(AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginWaitForChannel(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Close(TimeSpan timeout)
        {
            throw new NotImplementedException();
        }

        public void EndClose(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public void EndOpen(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public bool EndWaitForChannel(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public T GetProperty<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            throw new NotImplementedException();
        }

        public void Open(TimeSpan timeout)
        {
            throw new NotImplementedException();
        }

        public bool WaitForChannel(TimeSpan timeout)
        {
            throw new NotImplementedException();
        }
    }
}
