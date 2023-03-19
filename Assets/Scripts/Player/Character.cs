using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb2d;

    [Header("Variables")]
    [SerializeField] private float jumpPower = 100;
    private float jumpDelay = 0;
    private bool isGrounded = true;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        jumpDelay -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
            Jump();
    }

    private void Jump()
    {
        if (!isGrounded)
            return;

        jumpDelay = 0.1f;

        isGrounded = false;
        rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Ground") && jumpDelay <= 0)
            isGrounded = true;
    }
}
