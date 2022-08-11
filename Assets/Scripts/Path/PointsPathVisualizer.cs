using UnityEngine;

public class PointsPathVisualizer : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Point[] points = GetComponentsInChildren<Point>();
        if (points.Length <= 1)
            return;
        Gizmos.color = Color.yellow;
        for (int i = 0; i < points.Length; i++)
        {
            if (i + 1 <= points.Length - 1)
            {
                Gizmos.DrawLine(points[i].transform.position, points[i + 1].transform.position);
            }
        }
    }
}
