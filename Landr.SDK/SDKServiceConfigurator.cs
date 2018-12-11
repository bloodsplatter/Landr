using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Landr.SDK
{
    public sealed class SDKServiceConfigurator : IDisposable
    {
        public ContainerBuilder ContainerBuilder { get; }

        public SDKServiceConfigurator(IServiceCollection services)
        {
            ContainerBuilder = new ContainerBuilder();
            ContainerBuilder.Populate(services);
        }


        public void Dispose()
        {
            
        }
    }
}
