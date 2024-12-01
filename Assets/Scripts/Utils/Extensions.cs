using UnityEngine;

public static class Extensions
{
    private static Matrix4x4 _isometricMatrix = Matrix4x4.Rotate(Quaternion.Euler(0.0f, 45.0f, 0.0f));

    public static Vector3 ToIsometric(this Vector3 v)
    {
        return _isometricMatrix.MultiplyPoint3x4(v);
    }
}