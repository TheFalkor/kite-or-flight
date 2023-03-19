using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Obstacle
{
    [Header("References")]
    private Transform kiteTransform;


    void Start()
    {
        kiteTransform = GameObject.FindGameObjectWithTag("Kite").transform;
    }

    void Update()
    {
        float targetY = transform.position.y;
        if (transform.position.x > kiteTransform.position.x)
            targetY = kiteTransform.position.y;

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(-20, targetY), speed * Time.deltaTime);
    }
}
