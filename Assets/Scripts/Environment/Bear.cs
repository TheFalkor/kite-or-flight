using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Obstacle
{
    [Header("Variables")]
    [SerializeField] private float bearY = -2.75f;


    void Start()
    {
        interactWithPlayer = true;
        transform.position = new Vector2(transform.position.x, bearY);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(-20, bearY), speed * Time.deltaTime);

        if (transform.position.x == -20)
            RemoveObstacle();
    }
}
