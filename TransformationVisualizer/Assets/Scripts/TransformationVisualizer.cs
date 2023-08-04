using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationVisualizer : MonoBehaviour
{
    public GameObject pointPrefeb;

    public float pointSize = 0.01f;
    public int resolution = 12;

    struct Point
    {
        public Vector3 localPosition;
        public Transform transform;
    }
    List<Point> points;

    public List<Transformation> transformations;
    
    void Start()
    {
        points = new List<Point>();
        for (int x = 0; x < resolution; x++)
        {
            for (int y = 0; y < resolution; y++)
            {
                for (int z = 0; z < resolution; z++)
                {
                    CreatePoint(x, y, z);
                }
            }
        }
        UpdatePoints();
    }
    void Update()
    {
        UpdatePoints();
    }
    void UpdatePoints()
    {
        Matrix4x4 transformationMatrix = Matrix4x4.identity;
        if (transformations != null)
        {
            for (int i = 0; i < transformations.Count; i++)
            {
                if (transformations[i] == null)
                {
                    continue;
                }
                transformationMatrix *= transformations[i].GetMatrix();
            }
        }

        foreach (Point point in points)
        {
            point.transform.localScale = Vector3.one * pointSize;
            Vector4 calculatedPoint = transformationMatrix * new Vector4(point.localPosition.x, point.localPosition.y, point.localPosition.z, 1);
            point.transform.position = calculatedPoint / calculatedPoint.w;
        }
    }
    void CreatePoint(int x, int y, int z)
    {
        GameObject pointObject = Instantiate(pointPrefeb);

        Point point = new Point();
        point.localPosition = new Vector3(x, y, z) / (resolution - 1) - Vector3.one * 0.5f;
        point.transform = pointObject.transform;
        point.transform.parent = transform;

        pointObject.GetComponent<Renderer>().material.color
            = new Color((float)x / (resolution - 1), (float)y / (resolution - 1), (float)z / (resolution - 1));

        points.Add(point);
    }
}
