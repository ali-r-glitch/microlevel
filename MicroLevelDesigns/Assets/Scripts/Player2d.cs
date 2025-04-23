using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2d : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gravityStrength = 9.8f;
    [SerializeField] private float jumpForce = 5f;   
    private float groundCheckDistance = 5f;
    [SerializeField] private LayerMask groundLayer;
    private Vector3 velocity;
    private bool isGrounded;
    private bool floor;
    public SwitchManager switchManager;

    void Update()
    {
        CheckGrounded();
        if (floor)
        {
             playermoveing();
        }
        else
        {
            falling();
        }

       
        
    }
    private void falling()
    {
        transform.position+=Vector3.back*9.8f*Time.deltaTime;
    }
    private void CheckGrounded()
    {
        Ray ray = new Ray(transform.position, Vector3.back);
        floor = Physics.Raycast(ray, groundCheckDistance, groundLayer);
    }

    private void playermoveing()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        //float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(moveX, 0f, 0f).normalized;
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        if (!isGrounded)
        {
            velocity += Vector3.back * gravityStrength * Time.deltaTime;
        }

        transform.position += velocity * Time.deltaTime;

        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity = -Vector3.back * jumpForce;  // push in the opposite of gravity (up is -back)
            isGrounded = false;  // No longer grounded during jump
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy")||collision.gameObject.CompareTag("Spike"))
        {
            switchManager.deathscreen();
        }
        if (collision.gameObject.CompareTag("GroundLayer"))
        {
            Debug.Log("Hit ground: " + collision.gameObject.name);
            isGrounded = true;
            velocity = Vector3.zero;
        }
    }
    public void kill()
    {
        switchManager.deathscreen();
        
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("GroundLayer"))
        {
            Debug.Log("Left ground: " + collision.gameObject.name);
            isGrounded = false;
        }
    }
}