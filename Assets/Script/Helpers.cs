using UnityEngine;
using UnityEngine.Windows;

public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIsometric(this Vector3 input)
    {
        if (input.magnitude < 0.01f) return Vector3.zero;
        return _isoMatrix.MultiplyPoint3x4(input);
    }
}
