using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Math
{

    public static Vector3 Perpendicular(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        Vector3 v1 = (p3 - p1).normalized;
        Vector3 v2 = (p2 - p1).normalized;
        return Vector3.Cross(v1,v2);
    }

    public static Vector3 Perpendicular(Vector3 v1, Vector3 v2)
    {
        return Vector3.Cross(v1,v2).normalized;
    }

    public static float Hypotenuse(float d1, float d2, bool inverse)
    {
        if(inverse)
            return Mathf.Sqrt( Mathf.Pow(d1,2) - Mathf.Pow(d2,2) );
        else
            return Mathf.Sqrt( Mathf.Pow(d1,2) + Mathf.Pow(d2,2) );
    }

}
