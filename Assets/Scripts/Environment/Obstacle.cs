using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [Header("Runtime Variables")]
    protected float speed;
    protected bool interactWithKite = false;
    protected bool interactWithPlayer = false;


    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (interactWithKite && col.CompareTag("Kite"))
        {
            Debug.Log("Kite crashed");
        }

        if (interactWithPlayer && col.CompareTag("Player"))
        {
            Debug.Log("Player crashed");
        }
    }
}
