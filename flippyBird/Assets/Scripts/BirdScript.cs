using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength = 5f;
    public bool birdIsAlive = true;

    public float maxFlightTime = 10f; // Time in seconds the bird can fly
    private float flightTimer = 0f;
    private bool flightTimeOver = false;

    void Update()
    {
        if (!flightTimeOver && birdIsAlive)
        {
            flightTimer += Time.deltaTime;

            if (flightTimer >= maxFlightTime)
            {
                flightTimeOver = true;
                Debug.Log("Flight time is over!");
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                myRigidbody.velocity = Vector2.up * flapStrength;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        birdIsAlive = false;
        Debug.Log("Bird has collided!");
    }
}
