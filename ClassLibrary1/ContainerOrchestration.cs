using DryIoc;
using System.Diagnostics;
using WpfApp1;

namespace ClassLibrary1
{
    public class ContainerOrchestration
    {
        public IContainer GetContainerWithRegistrations()
        {
            var container = new Container();

            container.Register<ServicesViewModel>(Reuse.Singleton, setup: Setup.With(asResolutionRoot: true));

            container.RegisterMany(new[] { typeof(IMyService), typeof(IAssemblyService) }, typeof(AssemblyService), Reuse.Singleton);
            container.RegisterMany(new[] { typeof(IMyService), typeof(ICultureService) }, typeof(CultureService), Reuse.Singleton);

            foreach (var entry in container.GetServiceRegistrations())
                Debug.WriteLine(entry.ServiceType.Name);

            return container;
        }
    }
}
