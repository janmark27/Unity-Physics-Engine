using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class bouncingSphere : MonoBehaviour
{
    public float height, newHeight, time, restitution, velocity;
    public static float gravity;
    public static Vector3 spherePosition;

    void Start()
    {
        velocity = 1.0f;
        gravity = 9.81f;
        height = 50.0f;
        restitution = 0.5f;
        time = 0.05f;
        newHeight = height;
        spherePosition = new Vector3(-90.0f, newHeight, 0.0f);
    }
    void Update()
    {
        spherePosition.x = spherePosition.x + 0.5f; // X Axis constant movement
        if (newHeight >= 0.2f)
        {
            if (spherePosition.y > newHeight) // Inverse velocity once it reaches the maximum height
            {
                velocity = Mathf.Sqrt(2 * gravity * newHeight); // New initial velocity considering the height where it's been falling from
                velocity = -velocity;
            }
            if (spherePosition.y < 0.0f)// Inverse velocity once it reaches the floor
            {
                newHeight -= Mathf.Pow(restitution, 2) * height; // Calculate new height once it bounces with the coefficient of restitution of the floor
                velocity = Mathf.Sqrt(2 * gravity * newHeight);  // New initial velocity considering the height it's going to reach
                height = newHeight;
            }
            velocity = velocity - (gravity * time);
            spherePosition.y = spherePosition.y + velocity * time; // transform position of the sphere vector 
            this.transform.position = spherePosition;
        }
    }
}