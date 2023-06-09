using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kite : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform topPoint;
    [SerializeField] private Transform bottomPoint;
    [SerializeField] private Transform kiteTransform;
    [SerializeField] private BoxCollider2D boundingBox;

    [Header("Setup")]
    [SerializeField] private float keyKiteSpeed = 3;
    [SerializeField] private float mouseKiteSpeed = 90;
    [SerializeField] private float mouseMoveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float downAngle, upAngle;
    [SerializeField] private bool lockYAxis;

    private float minHeight = -0.5f;
    private float maxHeight = 4;

    private Vector3 previousPosition, deltaVector;
    private Rigidbody2D rb;
    private bool isDead = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateRope();
        ServiceLocator.Get<GameManager>().OnDeath += OnDeath;
    }


    void Update()
    {
        if (isDead)
        {
            UpdateRope();
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, -4.5f), Time.deltaTime * 6);
            return;
        }

        if (lockYAxis)
        {
            transform.position += Vector3.up * Input.GetAxis("Mouse Y") * mouseKiteSpeed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minHeight, maxHeight), transform.position.z);
        }
        else
        {
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldMousePos.z = 0f;
            rb.position = Vector3.MoveTowards(transform.position, worldMousePos, mouseMoveSpeed * Time.deltaTime);
            Vector3 extents = boundingBox.bounds.extents;
            if (rb.position.x < boundingBox.bounds.center.x - extents.x)
            {
                rb.position = new Vector3(boundingBox.bounds.center.x - extents.x, rb.position.y);
            }
            if (rb.position.x > boundingBox.bounds.center.x + extents.x)
            {
                rb.position = new Vector3(boundingBox.bounds.center.x + extents.x, rb.position.y);
            }
            if (rb.position.y < boundingBox.bounds.center.y - extents.y)
            {
                rb.position = new Vector3(rb.position.x, boundingBox.bounds.center.y - extents.y);
            }
            if (rb.position.y > boundingBox.bounds.center.y + extents.y)
            {
                rb.position = new Vector3(rb.position.x, boundingBox.bounds.center.y + extents.y);
            }
        }

        UpdateRope();

        RotateKite();

        previousPosition = transform.position;
    }

    private void RotateKite()
    {
        if (transform.position - previousPosition != Vector3.zero)
            deltaVector = transform.position - previousPosition;

        float currentRotation = transform.localEulerAngles.z;
        float rotationInRad = Mathf.Atan2(deltaVector.y, deltaVector.x);
        float newRotation = Mathf.MoveTowardsAngle(currentRotation, rotationInRad * Mathf.Rad2Deg, rotationSpeed * Time.deltaTime);
        transform.localEulerAngles = new Vector3(0f, 0f, newRotation);
    }

    public void MoveUp(float deltaTime)
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, maxHeight), keyKiteSpeed * deltaTime);
    }

    public void MoveDown(float deltaTime)
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, minHeight), keyKiteSpeed * deltaTime);
    }

    private void UpdateRope()
    { 
        float length = (topPoint.position - bottomPoint.position).magnitude;
        float angle = Mathf.Atan2(topPoint.position.y - bottomPoint.position.y, topPoint.position.x - bottomPoint.position.x);
        
        kiteTransform.localScale = new Vector3(0.075f, length);
        kiteTransform.position = (topPoint.position + bottomPoint.position) / 2;
        kiteTransform.localEulerAngles = new Vector3(0, 0, angle * Mathf.Rad2Deg + 90);
    }

    private void OnDeath(bool isKite)
    {
        isDead = true;
    }
}
