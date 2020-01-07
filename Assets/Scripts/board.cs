using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class board : MonoBehaviour
{
    billiardBall callBall;
    public float frictionCoefficient = 0;
    public static Vector3 friction = new Vector3(0.0f, 0.0f, 0.0f);

    void Start(){callBall = FindObjectOfType<billiardBall>();}
    void Update()
    {
        callBall = FindObjectOfType<billiardBall>();
        friction = callBall.ballVel * frictionCoefficient; // The friction is a fraction of the value of the velocity vector
        callBall.ballVel -= friction; // the friction is always the opposite direction as the velocity, gradually decreases the velocity
    }
}