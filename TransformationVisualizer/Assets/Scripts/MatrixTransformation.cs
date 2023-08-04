using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixTransformation : Transformation
{
    public Vector4 row0;
    public Vector4 row1;
    public Vector4 row2;
    public Vector4 row3;
    public bool inverse;
    public override Matrix4x4 GetMatrix()
    {
        Matrix4x4 matrix = new Matrix4x4();
        matrix.SetRow(0, row0);
        matrix.SetRow(1, row1);
        matrix.SetRow(2, row2);
        matrix.SetRow(3, row3);

        return inverse ? matrix.inverse : matrix;
    }
}
