using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MiniCore.Container.Wcf
{
    public class MiniCoreServiceHost : ServiceHost
    {
        private readonly IContainer _container;

        public MiniCoreServiceHost(IContainer container, Type serviceType, Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
            _container = container;
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            Description.Behaviors.Add(new MiniCoreInstanceProviderBehaviour(new MiniCoreInstanceProvider(_container)));
            base.OnOpen(timeout);
        }
    }
}
