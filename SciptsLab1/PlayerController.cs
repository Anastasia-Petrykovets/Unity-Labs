using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float posYToDie;
    private bool isGrounded = true;
    
    private void Update()
    {
        Movement();
        Jump();
        CheckLoseCondition();
    }

    private void CheckLoseCondition()
    {
        if (transform.position.y < posYToDie)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!isGrounded && other.gameObject.CompareTag("Ground")) isGrounded = true;
    }

    private void Movement()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        
        if (horizontalInput == 0) return;
        else
            transform.localEulerAngles = horizontalInput < 0 ? new Vector3(0, 180, 0) : Vector3.zero;
    }

    private void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
        }
    }
    
}
