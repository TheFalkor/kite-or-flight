using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Obstacle
{
    [Header("Variables")]
    [SerializeField] private float targetSpeed = 10;

    [Header("References")]
    private Transform kiteTransform;

    [Header("Runtime Variables")]
    private bool hasScreamed = false;


    void Start()
    {
        kiteTransform = GameObject.FindGameObjectWithTag("Kite").transform;
    }

    void Update()
    {
        float targetY = transform.position.y;
        if (transform.position.x > kiteTransform.position.x)
            targetY = kiteTransform.position.y;

        transform.position = new Vector2(transform.position.x, Mathf.MoveTowards(transform.position.y, targetY, Time.deltaTime * targetSpeed));
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(-20, transform.position.y), speed * Time.deltaTime);

        if (!hasScreamed && transform.position.x < 7)
        {
            hasScreamed = true;
            ServiceLocator.Get<AudioCore>().PlaySFX("BIRD");
        }
    }
}
