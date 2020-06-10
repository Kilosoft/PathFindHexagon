using PathFind;
using System.Collections.Generic;
using UnityEngine;

namespace PathFind
{
    public class VisualPathView : MonoBehaviour
    {
        [SerializeField] private MapController m_mapController;
        [SerializeField] private LineRenderer m_lineRenderer;
        private void Start()
        {
            m_mapController.OnPathFind += OnPathFind;
        }

        private void OnPathFind(IList<ICell> path)
        {
            var mapSize = m_mapController.GetMapSize();

            if (path != null && path.Count > 0)
            {
                var positions = new List<Vector3>();
                foreach (var cell in path)
                {
                    var point = cell.Point;
                    var position = HexCoords.GetHexVisualCoords(point, mapSize);
                    position.y += 0.3f;
                    positions.Add(position);
                }
                m_lineRenderer.positionCount = positions.Count;
                m_lineRenderer.SetPositions(positions.ToArray());
            }
            else
            {
                m_lineRenderer.positionCount = 0;
            }
        }

        private void OnDestroy()
        {
            m_mapController.OnPathFind -= OnPathFind;
        }
    }
}