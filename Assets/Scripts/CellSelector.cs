using PathFind;
using System;
using UnityEngine;

namespace PathFind
{
    public class CellSelector : MonoBehaviour
    {
        [SerializeField] private Camera m_camera;

        public Action<Vector2Int> OnStartPoint = delegate { };
        public Action<Vector2Int> OnEndPoint = delegate { };

        enum MouseButton
        {
            None = 0,
            Left = 1,
            Right = 2
        }

        private void Update()
        {
            var mouseButton = Input.GetMouseButtonDown(0) ? MouseButton.Left : Input.GetMouseButtonDown(1) ? MouseButton.Right : MouseButton.None;
            if (mouseButton != MouseButton.None)
            {
                var ray = m_camera.ScreenPointToRay(Input.mousePosition);
                var cell = Raycast(ray);
                if (cell != null)
                {
                    var point = cell.GetPoint();
                    if (mouseButton == MouseButton.Left) OnStartPoint?.Invoke(point);
                    if (mouseButton == MouseButton.Right) OnEndPoint?.Invoke(point);
                }
            }
        }

        private CellView Raycast(Ray ray)
        {
            var result = default(CellView);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                result = hit.transform.GetComponent<CellView>();
            }
            return result;
        }

    }
}