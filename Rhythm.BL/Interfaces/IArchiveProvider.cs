using System.Collections;

namespace Rhythm.BL.Interfaces
{
    public interface IArchiveProvider : IEnumerable, IEnumerator
    {
        void AddArchives();
    }
}
