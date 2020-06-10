using UnityEngine;

namespace PathFind
{
    public class CellView : MonoBehaviour
    {
        private Vector2Int _point;

        public void SetPoint(Vector2Int point)
        {
            _point = point;
        }

        public Vector2Int GetPoint() => _point;
    }
}
