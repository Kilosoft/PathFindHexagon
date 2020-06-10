using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PathFind
{
    public class PathFinder : IPathFinder
    {
        public IList<ICell> FindPathOnMap(ICell cellStart, ICell cellEnd, IMap map)
        {
            var findPath = new List<ICell>();
            if (cellStart == null || cellEnd == null) return findPath;

            var mapSize = map.GetMapSize();
            var mapDic = map.GetCells();

            var opened = new HashSet<ICell>();
            var closed = new HashSet<ICell>();

            opened.Add(cellStart);

            var moveList = new List<Vector2Int>(8);
            var isFindEnd = false;

            var mapRect = new RectInt(0, 0, mapSize.x, mapSize.y);

            while (opened.Count > 0)
            {
                var minOpened = opened.OrderBy(x => x.Summ).First();
                closed.Add(minOpened);
                opened.Remove(minOpened);

                if (minOpened.Point.y % 2 != 0)
                {
                    var n1 = new Vector2Int(minOpened.Point.x, minOpened.Point.y - 1);
                    var n2 = new Vector2Int(minOpened.Point.x + 1, minOpened.Point.y - 1);
                    var n3 = new Vector2Int(minOpened.Point.x - 1, minOpened.Point.y);
                    var n4 = new Vector2Int(minOpened.Point.x + 1, minOpened.Point.y);
                    var n5 = new Vector2Int(minOpened.Point.x, minOpened.Point.y + 1);
                    var n6 = new Vector2Int(minOpened.Point.x + 1, minOpened.Point.y + 1);
                    moveList.Add(n1);
                    moveList.Add(n2);
                    moveList.Add(n3);
                    moveList.Add(n4);
                    moveList.Add(n5);
                    moveList.Add(n6);
                }
                else
                {
                    var n1 = new Vector2Int(minOpened.Point.x - 1, minOpened.Point.y - 1);
                    var n2 = new Vector2Int(minOpened.Point.x, minOpened.Point.y - 1);
                    var n3 = new Vector2Int(minOpened.Point.x - 1, minOpened.Point.y);
                    var n4 = new Vector2Int(minOpened.Point.x + 1, minOpened.Point.y);
                    var n5 = new Vector2Int(minOpened.Point.x - 1, minOpened.Point.y + 1);
                    var n6 = new Vector2Int(minOpened.Point.x, minOpened.Point.y + 1);
                    moveList.Add(n1);
                    moveList.Add(n2);
                    moveList.Add(n3);
                    moveList.Add(n4);
                    moveList.Add(n5);
                    moveList.Add(n6);
                }

                for (int i = 0; i < moveList.Count; i++)
                {
                    var movePosition = moveList[i];
                    if (mapRect.Contains(movePosition))
                    {
                        var element = mapDic[movePosition];
                        if (closed.Contains(element) == false && element.IsWall == false)
                        {
                            var isOpened = opened.Contains(element);
                            var addDistance = 10;
                            var distance = minOpened.Distance + addDistance;
                            
                            if (isOpened)
                            {
                                if (element.Distance > minOpened.Distance + addDistance)
                                {
                                    element.SetDistance(distance);
                                    element.SetParent(minOpened);
                                }
                            }
                            else
                            {
                                opened.Add(element);
                                element.SetDistance(distance);
                                element.SetParent(minOpened);
                            }

                            var HeurX = element.Point.x > cellEnd.Point.x ? element.Point.x - cellEnd.Point.x : cellEnd.Point.x - element.Point.x;
                            var HeurY = element.Point.y > cellEnd.Point.y ? element.Point.y - cellEnd.Point.y : cellEnd.Point.y - element.Point.y;
                            element.SetHeuristic((int)Math.Sqrt(HeurX * HeurX + HeurY * HeurY) * addDistance);

                            if (element == cellEnd)
                            {
                                isFindEnd = true;
                            }
                            else
                            {
                                if (!opened.Contains(element))
                                    opened.Add(element);
                            }
                        }
                    }
                }
                moveList.Clear();
                if (isFindEnd)
                {
                    break;
                }
            }

            if (isFindEnd)
            {
                var current = cellEnd;
                findPath.Add(current);
                while (current != cellStart)
                {
                    current = current.Parent;
                    findPath.Add(current);
                }
            }

            //Reset
            foreach (var cellPair in mapDic)
            {
                var cell = cellPair.Value;
                cell.SetParent(null);
                cell.SetDistance(0);
                cell.SetWeight(0);
                cell.SetHeuristic(0);
            }

            return findPath;
        }
    }
}
