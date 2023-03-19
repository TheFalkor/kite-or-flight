using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [Header("Variables")]
    public float speed = 100;


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(-30, transform.position.y), speed * Time.deltaTime);

        if (transform.position.x == -30)
            transform.position = new Vector2(30, transform.position.y);
    }
}
