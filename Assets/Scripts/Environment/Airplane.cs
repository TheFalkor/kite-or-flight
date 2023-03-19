using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : Obstacle
{
    [Header("Variables")]
    [SerializeField] private float targetSpeed = 10;
    [SerializeField] private float speedModifier = 10;

    [Header("References")]
    private Transform kiteTransform;

    [Header("Runtime Variables")]
    private bool hasScreamed = false;
    private float gameOverSpeed;


    void Start()
    {
        transform.position = new Vector2(transform.position.x, Random.Range(2f, 6.5f));
        kiteTransform = GameObject.FindGameObjectWithTag("Kite").transform;
        interactWithKite = true;
    }

    void Update()
    {
        if (speed != 0)
            gameOverSpeed = speed;

        if (speed == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-40, transform.position.y), gameOverSpeed * speedModifier * Time.deltaTime);
            return;
        }

        float targetY = transform.position.y;
        if (transform.position.x > kiteTransform.position.x)
            targetY = kiteTransform.position.y;

        transform.position = new Vector2(transform.position.x, Mathf.MoveTowards(transform.position.y, targetY, Time.deltaTime * targetSpeed));
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(-40, transform.position.y), speed * Time.deltaTime * speedModifier);

        if (!hasScreamed && transform.position.x < 7)
        {
            hasScreamed = true;
            ServiceLocator.Get<AudioCore>().PlaySFX("AIRPLANE");
        }

        if (transform.position.x == -40)
            RemoveObstacle();
    }
}
