using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    [Header("Runtime Variables")]
    protected float speed;


    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Kite"))
        {
            Debug.Log("Kite crashed");
        }

        if (col.CompareTag("Player"))
        {
            Debug.Log("Player crashed");
        }
    }
}
