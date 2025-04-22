using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2d : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gravityStrength = 9.8f;
    private Vector3 velocity;
    private bool isGrounded;

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(moveX, 0f, moveZ).normalized;
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        if (!isGrounded)
        {
            velocity += Vector3.back * gravityStrength * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GroundLayer"))
        {
            Debug.Log("Hit ground: " + collision.gameObject.name);
            isGrounded = true;
            velocity = Vector3.zero;
        }
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