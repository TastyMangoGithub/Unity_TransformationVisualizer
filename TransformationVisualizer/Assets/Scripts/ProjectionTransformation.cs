using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectionTransformation : Transformation
{
    public float fov;
    public float near;
    public float far;

    public override Matrix4x4 GetMatrix()
    {
        float d = 1.0f/Mathf.Tan(fov*Mathf.Deg2Rad * 0.5f);
        float ratio = Screen.width / Screen.height;

        Matrix4x4 matrix = new Matrix4x4();
        matrix.SetRow(0, new Vector4(d/ratio, 0, 0, 0));
        matrix.SetRow(1, new Vector4(0, d, 0, 0));
        matrix.SetRow(2, new Vector4(0, 0, (near+far)/(far-near), (2.0f*far*near)/(far-near)));
        matrix.SetRow(3, new Vector4(0, 0, 1, 0));

        return matrix;
    }
    [ContextMenu("Get Value From Camera")]
    void GetValueFromCamera() {
        Camera camera = Camera.main;
        fov = camera.fieldOfView;
        near = camera.nearClipPlane;
        far = camera.farClipPlane;
    }
    
}
