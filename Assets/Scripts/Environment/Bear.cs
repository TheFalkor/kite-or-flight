using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Obstacle
{
    [Header("Variables")]
    [SerializeField] private float bearY = -2.75f;

    [Header("Runtime Variables")]
    private bool hasRoared = false;


    void Start()
    {
        bearY += Random.Range(-0.1f, 0.1f);

        interactWithPlayer = true;
        transform.position = new Vector2(transform.position.x, bearY);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(-20, bearY), speed * Time.deltaTime);

        if (transform.position.x == -20)
            RemoveObstacle();

        if (!hasRoared && transform.position.x < 10)
        {
            hasRoared = true;
            ServiceLocator.Get<AudioCore>().PlaySFX("BEAR_SPAWN");
        }
    }

    protected override void OnCollider()
    {
        ServiceLocator.Get<AudioCore>().PlaySFX("BEAR_ATTACK");
    }
}
