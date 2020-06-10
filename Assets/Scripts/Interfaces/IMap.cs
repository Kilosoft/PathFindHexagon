using System.Collections.Generic;
using UnityEngine;

namespace PathFind
{
    public interface IMap
    {
        Vector2Int GetMapSize();
        void SetCell(ICell cell);
        ICell GetCell(Vector2Int point);
        IDictionary<Vector2Int, ICell> GetCells();
    }
}