using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ServiceLibrary
{
    public sealed class AssemblyService : IMyService, IAssemblyService
    {
        public string Name => "AssemblyService";

        public ICollection<string> Items => new ObservableCollection<string>(GetType().Assembly.GetReferencedAssemblies().Select(p => p.Name));
    }
}
