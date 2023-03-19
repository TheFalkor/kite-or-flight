using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb2d;
    [SerializeField] private GameObject landPS, jumpPS;

    [Header("Variables")]
    [SerializeField] private float jumpPower = 100;
    private float jumpDelay = 0;
    private bool isGrounded = true;
    private Transform ground;
    private Animator animator;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ground = GameObject.FindWithTag("Ground").transform;
        animator = GetComponentInChildren<Animator>();
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

        Instantiate(jumpPS,transform.position, Quaternion.identity, ground);
        animator.SetTrigger("jump");
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Ground") && jumpDelay <= 0)
            isGrounded = true;

        Instantiate(landPS, transform.position, Quaternion.identity, ground);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        animator.SetBool("tripped", true);
    }
}
