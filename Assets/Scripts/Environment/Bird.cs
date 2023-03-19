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
    private float birdModifier = 1;


    void Start()
    {
        kiteTransform = GameObject.FindGameObjectWithTag("Kite").transform;
        interactWithKite = true;
        birdModifier = Random.Range(0, 0.5f);
    }

    void Update()
    {
        float targetY = transform.position.y;
        if (transform.position.x > kiteTransform.position.x)
            targetY = kiteTransform.position.y;

        transform.position = new Vector2(transform.position.x, Mathf.MoveTowards(transform.position.y, targetY, Time.deltaTime * targetSpeed));
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(-20, transform.position.y), speed * birdModifier * Time.deltaTime);

        if (!hasScreamed && transform.position.x < 7)
        {
            hasScreamed = true;
            ServiceLocator.Get<AudioCore>().PlaySFX("BIRD");
        }

        if (transform.position.x == -20)
            RemoveObstacle();
    }
}
