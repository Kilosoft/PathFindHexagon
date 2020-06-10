using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Extensions.Linq;

namespace PathFind
{
    [CreateAssetMenu(fileName = "CellAssets", menuName = "PathFind/CellAssets")]
    public class CellAssets : ScriptableObject
    {
        [SerializeField] private List<CellPrefab> m_prefabs;

        public CellPrefab GetRandomPrefab(bool isWalkable)
        {
            return m_prefabs.Where(x => x.IsWall != isWalkable).Random();
        }
    }
}