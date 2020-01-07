using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorLibrary : MonoBehaviour
{
    Vector3 v1 = new Vector3(7.0f, -2.1f, 6.3f),
            v2 = new Vector3(-3.2f, -4.9f, 7.0f);
 
    public static Vector3 addVectors(Vector3 v1, Vector3 v2)
    {
        Vector3 vecResult = new Vector3();
        vecResult.x = v1.x + v2.x;
        vecResult.y = v1.y + v2.y;
        vecResult.z = v1.z + v2.z;
        return vecResult;
    }
    public static Vector3 subtractVectors(Vector3 v1, Vector3 v2)
    {
        Vector3 vecResult = new Vector3();
        vecResult.x = v2.x - v1.x;
        vecResult.y = v2.y - v1.y;
        vecResult.z = v2.z - v1.z;
        return vecResult;
    }
    public static float dotProduct(Vector3 vector1, Vector3 vector2)
    {
        float dotProductResult = (vector1.x * vector2.x) + (vector1.y * vector2.y) + (vector1.z * vector2.z);
        return dotProductResult;
    }
    public static float crossProduct(Vector3 vector1, Vector3 vector2)
    {
        float crossProductResult = (vector1.x * vector2.y) + (vector1.y * vector2.z) + (vector1.z * vector2.x);
        return crossProductResult;
    }
    public static float vectorMagnitude(Vector3 v)
    {
        float vectorMagnitudeResult = Mathf.Sqrt(Mathf.Pow(v.x, 2) + Mathf.Pow(v.y, 2) + Mathf.Pow(v.z, 2));
        return vectorMagnitudeResult;
    }
    public static Vector3 unitVector(Vector3 v)
    {
        return new Vector3(v.x / vectorMagnitude(v), v.y / vectorMagnitude(v), v.z / vectorMagnitude(v));
    }
    public static float unitDirectionVector(Vector3 v1, Vector3 v2)
    {
        return Mathf.Atan(v2.z - v2.z / v2.x - v1.x);
    }
    public static Vector3 scalarMultiple3DVector(Vector3 v, float scalar)
    {
        v.x = scalar * v.x;
        v.y = scalar * v.y;
        v.z = scalar * v.z;
        return v;
    }
    public static Vector3 vectorReflectionAligned(Vector3 v)
    {
        v.x = -v.x;
        v.y = -v.y;
        v.z = -v.z;
        return v;
    }
    public static Vector3 vectorReflectionNotAligned(Vector3 v)
    {
        v.x = -v.x;
        v.y = -v.y;
        v.z = -v.z;
        return v;
    }
    public static bool vectorsNearlyEqualWithRadius(Vector3 v1, Vector3 v2, float radius)
    {
        if(vectorMagnitude(subtractVectors(v1, v2)) < Mathf.Abs(radius)){return true;}
        return false;
    }
    public static Vector3 VectorZero3D()
    {
        return new Vector3();
    }

    void Start()
    {
        Debug.Log("Vector 1 + Vector 2:");
        Debug.Log(addVectors(v1, v2));
        Debug.Log("Vector 1 - Vector 2:");
        Debug.Log(subtractVectors(v1,v2));
        Debug.Log("Dot Product of Vector 1 and Vector 2");
        Debug.Log(dotProduct(v1,v2));
        Debug.Log("Cross Product of Vector 1 and Vector 2");
        Debug.Log(crossProduct(v1,v2));
        Debug.Log("Vector Magnitude of Vector 1:");
        Debug.Log(vectorMagnitude(v1));
        Debug.Log("Unit Vector of Vector 1");
        Debug.Log(unitVector(v1));
        Debug.Log("Unit Direction of Vector 1");
        Debug.Log(unitDirectionVector(v1,v2));
        Debug.Log("Scalar Multiple Vector 1 and 2");
        Debug.Log(scalarMultiple3DVector(v1,2));
        Debug.Log("Aligned reflection of Vector 1");
        Debug.Log(vectorReflectionAligned(v1));
        Debug.Log("Not aligned reflection of Vector 1");
        Debug.Log(vectorReflectionNotAligned(v1));
        Debug.Log("Radius Collision of Vector 1 and Vector 2");
        Debug.Log(vectorsNearlyEqualWithRadius(v1,v2,2));
        Debug.Log("Return Vector Zero");
        Debug.Log(VectorZero3D());
    }
    void Update(){}
}
