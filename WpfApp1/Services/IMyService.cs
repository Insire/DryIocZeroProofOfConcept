using System.Collections.Generic;

namespace WpfApp1
{
    public interface IMyService
    {
        string Name { get; }

        ICollection<string> Items { get; }
    }
}
