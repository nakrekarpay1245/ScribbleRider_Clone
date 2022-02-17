using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;

    public List<Vector3> points;

    float nextTimeToMousePosition = 0;
    float mousePositionRate = 0.025f;

    public void UpdateLine(Vector3 mousePosition)
    {
        if (points == null)
        {
            points = new List<Vector3>();
            SetPoint(mousePosition);
            return;
        }

        if (Time.time > nextTimeToMousePosition)
        {
            nextTimeToMousePosition = Time.time + mousePositionRate;

            SetPoint(mousePosition);
        }
    }

    private void SetPoint(Vector2 mousePosition)
    {
        points.Add(mousePosition);

        lineRenderer.numPositions = points.Count;
        lineRenderer.SetPosition(points.Count - 1, mousePosition);
    }
}