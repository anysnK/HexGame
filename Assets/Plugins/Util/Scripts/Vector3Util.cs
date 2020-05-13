using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3Util : MonoBehaviour
{
    public static Vector3 ClampMinMax(Vector3 vector, float lengthMin, float lengthMax)
    {
        float vectorSqrMagnitude = vector.sqrMagnitude;
        if(vectorSqrMagnitude > lengthMax * lengthMax)
        {
            return vector.normalized * lengthMax;
        }
        if(vectorSqrMagnitude < lengthMin * lengthMin)
        {
            return vector.normalized * lengthMin;
        }
        return vector;
    }
}
