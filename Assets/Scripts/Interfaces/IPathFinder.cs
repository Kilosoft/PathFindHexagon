using System.Collections.Generic;

namespace PathFind
{
    public interface IPathFinder
    {
        IList<ICell> FindPathOnMap(ICell cellStart, ICell cellEnd, IMap map);
    }
}
