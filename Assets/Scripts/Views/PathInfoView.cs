using PathFind;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PathFind
{
    public class PathInfoView : MonoBehaviour
    {
        [SerializeField] private MapController m_mapController;
        [SerializeField] private TMP_Text m_startCelllValue;
        [SerializeField] private TMP_Text m_endCelllValue;
        [SerializeField] private TMP_Text m_distanceValue;


        private void Start()
        {
            m_mapController.OnStartCellSelect += OnStartCellSelect;
            m_mapController.OnEndCellSelect += OnEndCellSelect;
            m_mapController.OnPathFind += OnFindPath;
        }

        private void OnFindPath(IList<ICell> path)
        {
            if (path != null && path.Count > 0)
            {
                m_distanceValue.text = path.Count.ToString();
            }
            else
            {
                m_distanceValue.text = "path no find";
            }
        }

        private void OnStartCellSelect(ICell cell)
        {
            m_startCelllValue.text = cell.Point.ToString();
        }
        private void OnEndCellSelect(ICell cell)
        {
            m_endCelllValue.text = cell.Point.ToString();
        }

        private void OnDestroy()
        {
            m_mapController.OnStartCellSelect -= OnStartCellSelect;
            m_mapController.OnEndCellSelect -= OnEndCellSelect;
            m_mapController.OnPathFind -= OnFindPath;
        }
    }
}