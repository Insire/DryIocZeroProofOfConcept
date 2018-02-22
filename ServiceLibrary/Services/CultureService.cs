using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace ServiceLibrary
{
    public sealed class CultureService : IMyService, ICultureService
    {
        public string Name => "CultureService";

        public ICollection<string> Items => new ObservableCollection<string>(CultureInfo.GetCultures(CultureTypes.NeutralCultures).Select(p => p.DisplayName));
    }
}
