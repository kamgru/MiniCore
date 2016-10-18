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
    public class MiniCoreInstanceProvider : IInstanceProvider
    {
        private readonly IContainer _container;

        public MiniCoreInstanceProvider(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            _container = container;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            var type = instanceContext.Host.Description.ServiceType;
            return _container.Resolve(type);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return this.GetInstance(instanceContext);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {            
        }
    }
}
