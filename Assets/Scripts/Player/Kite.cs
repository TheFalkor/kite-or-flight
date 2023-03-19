using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kite : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform topPoint;
    [SerializeField] private Transform bottomPoint;

    [Header("Setup")]
    [SerializeField] private float keyKiteSpeed = 3;
    [SerializeField] private float mouseKiteSpeed = 90;

    private float minHeight = -0.5f;
    private float maxHeight = 4;


    void Update()
    {
        transform.position += Vector3.up * Input.GetAxis("Mouse Y") * mouseKiteSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minHeight, maxHeight), transform.position.z);
        UpdateRope();
    }


    void Start()
    {
        UpdateRope();
    }
    
    public void MoveUp(float deltaTime)
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, maxHeight), keyKiteSpeed * deltaTime);
        UpdateRope();
    }

    public void MoveDown(float deltaTime)
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, minHeight), keyKiteSpeed * deltaTime);
        UpdateRope();
    }

    private void UpdateRope()
    { 
        float length = (topPoint.position - bottomPoint.position).magnitude;
        float angle = Mathf.Atan2(topPoint.position.y - bottomPoint.position.y, topPoint.position.x - bottomPoint.position.x);
        
        transform.GetChild(0).localScale = new Vector3(0.075f, length);
        transform.GetChild(0).position = (topPoint.position + bottomPoint.position) / 2;
        transform.GetChild(0).localEulerAngles = new Vector3(0, 0, angle * Mathf.Rad2Deg - 47);
    }
}
