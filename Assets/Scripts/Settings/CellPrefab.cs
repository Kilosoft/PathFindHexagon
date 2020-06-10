using UnityEngine;

namespace PathFind
{
    [CreateAssetMenu(fileName = "CellPrefab", menuName = "PathFind/CellPrefab")]
    public class CellPrefab : ScriptableObject
    {
        public GameObject Prefab;
        public bool IsWall;
    }
}
