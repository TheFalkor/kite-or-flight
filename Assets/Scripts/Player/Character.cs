using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb2d;

    [Header("Variables")]
    [SerializeField] private float jumpPower = 100;
    private bool isGrounded = true;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            Jump();
    }

    private void Jump()
    {
        if (!isGrounded)
            return;

        isGrounded = false;
        rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Ground"))
            isGrounded = true;
    }
}
