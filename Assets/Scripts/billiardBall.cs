using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class billiardBall : MonoBehaviour
{
    public Vector3 ballPos = new Vector3(0.0f, 0.0f, 0.0f); // Ball coordinates
    public Vector3 ballVel = new Vector3(-1.0f, 0.0f, -1.0f); // Ball velocity
    void Start() {}
    void Update()
    {
        ballPos += ballVel; // Velocity changing the ball's position
        this.transform.position = ballPos;
    }
}