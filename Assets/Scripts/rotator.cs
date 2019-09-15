using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Transform.position example.
//
// Animate a sphere around a circle and bounce up and down.

public class rotator : MonoBehaviour
{
    private Vector3 spherePosition;
    private float xzPosition, yPosition;
    private float increaseXZPosition, increaseYPosition;
    public GameObject enemy;
    void Awake()
    {
        // Three seconds per circular rotation.
        increaseXZPosition = (2.0f * Mathf.PI) / 3.0f;
        spherePosition = this.enemy.transform.position;
        // Random speed up/down.
        increaseYPosition = (2.0f * Mathf.PI) / 1.3f;

        // Create a floor for the sphere to bounce on.
        GameObject quad;
        quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
        quad.transform.rotation = Quaternion.Euler(90, 0, 0);
        quad.transform.localScale = new Vector3(8, 8, 1);

        // Sphere is 1 unit in size.  Drop floor by half this.
        quad.transform.position = new Vector3(0.0f, -0.5f, 0.0f);

    }

    void Update()
    {
        // Move sphere around the circle.
        spherePosition = new Vector3(2.0f * Mathf.Sin(xzPosition), 4.0f * Mathf.Sin(yPosition), 2.0f * Mathf.Cos(xzPosition));
        transform.position = spherePosition;

        // Update the rotating position.
        xzPosition += increaseXZPosition * Time.deltaTime;
        if (xzPosition > 2.0f * Mathf.PI)
        {
            xzPosition = xzPosition - 2.0f * Mathf.PI;
        }

        // Update the up/down position.
        yPosition += increaseYPosition * Time.deltaTime;
        if (yPosition > Mathf.PI)
        {
            yPosition = yPosition - Mathf.PI;
        }
    }
}