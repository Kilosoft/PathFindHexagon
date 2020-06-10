using UnityEngine;

namespace PathFind
{
    public interface ICell
    {
        ICell Parent { get; }
        Vector2Int Point { get; }
        bool IsWall { get; }
        int Weight { get; }
        int Heuristic { get; }
        int Distance { get; }
        int Summ { get; }

        void SetParent(ICell parent);
        void SetIsWall(bool isWall);
        void SetWeight(int weight);
        void SetHeuristic(int heuristic);
        void SetDistance(int distance);
    }
}