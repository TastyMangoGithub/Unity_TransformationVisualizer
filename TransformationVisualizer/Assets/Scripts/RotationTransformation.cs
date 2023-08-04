using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTransformation : Transformation
{
    public Vector3 angles;
    public bool inverse;
    public override Matrix4x4 GetMatrix()
    {
        Matrix4x4 matrixX = new Matrix4x4();
        matrixX.SetRow(0, new Vector4(1, 0, 0, 0));
        matrixX.SetRow(1, new Vector4(0, Mathf.Cos(angles.x*Mathf.Deg2Rad), -Mathf.Sin(angles.x*Mathf.Deg2Rad), 0));
        matrixX.SetRow(2, new Vector4(0, Mathf.Sin(angles.x*Mathf.Deg2Rad), Mathf.Cos(angles.x*Mathf.Deg2Rad), 0));
        matrixX.SetRow(3, new Vector4(0, 0, 0, 1));

        Matrix4x4 matrixY = new Matrix4x4();
        matrixY.SetRow(0, new Vector4(Mathf.Cos(angles.y*Mathf.Deg2Rad), 0, Mathf.Sin(angles.y*Mathf.Deg2Rad), 0));
        matrixY.SetRow(1, new Vector4(0, 1, 0, 0));
        matrixY.SetRow(2, new Vector4(-Mathf.Sin(angles.y*Mathf.Deg2Rad), 0, Mathf.Cos(angles.y*Mathf.Deg2Rad), 0));
        matrixY.SetRow(3, new Vector4(0, 0, 0, 1));

        Matrix4x4 matrixZ = new Matrix4x4();
        matrixZ.SetRow(0, new Vector4(Mathf.Cos(angles.z*Mathf.Deg2Rad), -Mathf.Sin(angles.z*Mathf.Deg2Rad), 0, 0));
        matrixZ.SetRow(1, new Vector4(Mathf.Sin(angles.z*Mathf.Deg2Rad), Mathf.Cos(angles.z*Mathf.Deg2Rad), 0, 0));
        matrixZ.SetRow(2, new Vector4(0, 0, 1, 0));
        matrixZ.SetRow(3, new Vector4(0, 0, 0, 1));

        Matrix4x4 matrix = matrixY * matrixX * matrixZ;

        return inverse ? matrix.inverse : matrix;
    }
}
