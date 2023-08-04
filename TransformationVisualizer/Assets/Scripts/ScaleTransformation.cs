using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTransformation : Transformation
{
    public Vector3 scale;
    public bool inverse;
    public override Matrix4x4 GetMatrix()
    {
        Matrix4x4 matrix = new Matrix4x4();
        matrix.SetRow(0, new Vector4(scale.x, 0, 0, 0));
        matrix.SetRow(1, new Vector4(0, scale.y, 0, 0));
        matrix.SetRow(2, new Vector4(0, 0, scale.z, 0));
        matrix.SetRow(3, new Vector4(0, 0, 0, 1));

        return inverse ? matrix.inverse : matrix;
    }
}
