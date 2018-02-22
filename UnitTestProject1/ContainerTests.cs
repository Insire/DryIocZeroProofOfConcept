using ClassLibrary1;
using DryIoc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLibrary;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public sealed class ContainerTests
    {
        private static readonly ContainerOrchestration _orchestration = new ContainerOrchestration();

        [TestMethod]
        public void Should_Resolve_AllInstance_Of_IMyService()
        {
            var container = _orchestration.GetContainerWithRegistrations();

            Assert.AreEqual(3, container.ResolveMany(typeof(IMyService)).Count());
        }

        [TestMethod]
        public void Should_Resolve_ServicesViewModel()
        {
            var container = _orchestration.GetContainerWithRegistrations();

            Assert.AreEqual(1, container.ResolveMany(typeof(WpfApp1.ServicesViewModel)).Count());
        }
    }
}
