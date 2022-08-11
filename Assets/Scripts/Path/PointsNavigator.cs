using System;
using UnityEngine;

public class PointsNavigator : MonoBehaviour
{
    [SerializeField] private Point[] _points;
    public Point FirstPoint => _points[0] ?? null;
    public Point LastPoint => _points[_points.Length - 1];
    private void Awake()
    {
        _points = GetComponentsInChildren<Point>();
    }

    public Point GetNextPoint(Point point) 
    {
        return _points[Array.IndexOf(_points, point) + 1] ?? null;
    }

}
