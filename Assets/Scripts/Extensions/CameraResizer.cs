using UnityEngine;

namespace Extensions.Cameras
{
    [ExecuteInEditMode]
    public class CameraResizer : MonoBehaviour
    {
        [SerializeField] private Camera m_mainCamera;
        [SerializeField] private float m_minWidth;
        [SerializeField] private float m_minHeight;

        private void Update()
        {
            var ratio = (float)Screen.width / Screen.height;

            var size = 0;

            if (m_minWidth > size) m_mainCamera.orthographicSize = m_minHeight;
            var actualWidth = m_minHeight * ratio;
            if (m_minWidth > actualWidth) m_mainCamera.orthographicSize = m_minWidth / ratio;

        }
    }
}