using System.Collections.Generic;

namespace ServiceLibrary
{
    public interface IMyService
    {
        string Name { get; }

        ICollection<string> Items { get; }
    }
}
