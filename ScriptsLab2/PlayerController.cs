using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [Space] 
    [SerializeField] private List<Transform> coins = new List<Transform>();
    [SerializeField] private CanvasController canvas;
    private bool isGrounded = true;

    private void Start()
    {
        canvas.InitializeText(coins.Count);
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!isGrounded && other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            canvas.ChangeText();
        }
    }

    private void Move()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        var direction = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
        rb.AddForce(direction);
    }

    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }
}
