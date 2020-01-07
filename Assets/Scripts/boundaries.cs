using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundaries : MonoBehaviour
{
    [SerializeField] private Transform[] BoundariesList; // Access to boundaries
    billiardBall callBall; // Calls instance of the ball class
    public static Vector3 getFinalVelocity(Transform boundary, billiardBall callBall){return 2 * vectorProjection(boundary, callBall) + callBall.ballVel; } // Calculates where the ball will go after hitting the boundary
    public static Vector3 vectorProjection(Transform boundary, billiardBall callBall){return dotProduct(callBall.ballVel, getNormalized(boundary)) / Mathf.Pow(vectorMagnitude(getNormalized(boundary)), 2) * getNormalized(boundary);} //Calculates the projetion of the ball over the boundary
    private static Vector3 getNormalized(Transform boundary){float slope = (boundary.rotation.eulerAngles.y - 90.0f) * Mathf.Deg2Rad;  return new Vector3(-Mathf.Cos(slope), 0.0f, Mathf.Sin(slope));} //Gets the normal of the boundary hit
    public static bool checkCollision(Vector3 ballPos, float rad, Transform boundariesTransform, Vector3 midBound) // Checks if the ball has collided with the boundary 
    {
        float distance = distanceChecker(ballPos, midBound, boundariesTransform);
        bool collisionState = distance <= rad;
        return collisionState;
    }
    private static float distanceChecker(Vector3 ballPos, Vector3 midBound, Transform boundTransform) // Calculates the distance between the ball and the boundary
    {
        Vector3 ballToBoundDistance = subtractVectors(ballPos, boundTransform.position);
        return Mathf.Sqrt(Mathf.Pow(boundDis(ballToBoundDistance, boundTransform.right, midBound.x), 2) + Mathf.Pow(boundDis(ballToBoundDistance, boundTransform.up, midBound.y), 2) + 
               Mathf.Pow(boundDis(ballToBoundDistance, boundTransform.forward, midBound.z), 2));
    }
    private static float boundDis(Vector3 ballPos, Vector3 boundCollisionLine, float midBound) 
    {
        float DPResult = dotProduct(ballPos, boundCollisionLine), excess = 0.0f;
        if (DPResult < -midBound) { excess = DPResult + midBound; }
        else if (DPResult > midBound) { excess = DPResult - midBound; }
        return excess;
    }
    public static float dotProduct(Vector3 v1, Vector3 v2) { return -((v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z)); }
    public static float vectorMagnitude(Vector3 v) { return Mathf.Sqrt(Mathf.Pow(v.x, 2) + Mathf.Pow(v.y, 2) + Mathf.Pow(v.z, 2)); }
    public static Vector3 subtractVectors(Vector3 v1, Vector3 v2)
    {
        Vector3 vecResult = new Vector3();
        vecResult.x = v2.x - v1.x;
        vecResult.y = v2.y - v1.y;
        vecResult.z = v2.z - v1.z;
        return vecResult;
    }
    void Start(){}
    void Update()
    {
        callBall = FindObjectOfType<billiardBall>();
        foreach (Transform boundary in BoundariesList)
        {
            if (checkCollision(callBall.ballPos, 1.0f, boundary, boundary.localScale / 2)){callBall.ballVel = getFinalVelocity(boundary, callBall);}
        }
    }
}