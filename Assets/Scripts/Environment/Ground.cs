using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform otherGround;

    [Header("Runtime Variables")]
    private float speed;


    void Start()
    {

    }

    public void MoveGround(float deltaTime)
    {
        if (transform.parent == null)
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(-20, -4), speed * deltaTime);

        if (transform.position == new Vector3(-20, -4))
        {
            otherGround.parent = null;
            transform.parent = otherGround;
            transform.position = otherGround.position + new Vector3(20, 0);
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
