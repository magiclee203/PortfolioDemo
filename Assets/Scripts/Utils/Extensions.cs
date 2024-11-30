using UnityEngine;

public static class Extensions
{
    // TODO
    public static Vector3 ToIsometric(this Vector3 v)
    {
        return new Vector3(v.x, v.y, v.z);
    }
}