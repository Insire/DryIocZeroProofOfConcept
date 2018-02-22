using ServiceLibrary;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    public class ServicesViewModel
    {
        public ObservableCollection<IMyService> Items { get; }

        public ServicesViewModel(IAssemblyService assemblyService, ICultureService cultureService, IAsciiConverterService converter)
        {
            Items = new ObservableCollection<IMyService>(new List<IMyService>
            {
                //assemblyService,
                //cultureService,
                converter,
            });
        }
    }
}
