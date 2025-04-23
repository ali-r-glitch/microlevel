using System;
using UnityEngine;

public class Player2d : MonoBehaviour
{
    private float moveSpeed = 19f;
    private float gravity = 20f;
   [SerializeField] private float jumpForce = 24f;

    private float groundCheckDistance = 5f;
    [SerializeField] private LayerMask groundLayer;

    private Vector3 velocity;
    private bool isGrounded;
    private Rigidbody rb;

    public SwitchManager switchManager;

    // Clamp bounds
    private float minX = -87f;
     private float maxX = 15f;
     private float minZ = -159f;
    private float maxZ = 163f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckGrounded();
        HandleMovement();
        HandleJump();
        ApplyGravity();
        ClampPosition();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        Vector3 moveDir = new Vector3(moveX, 0f, 0f).normalized;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    void HandleJump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.z = jumpForce;  // Jump goes forward in Z (opposite of gravity)
            isGrounded = false;
        }
    }

    void ApplyGravity()
    {
        if (!isGrounded)
        {
            velocity.z -= gravity * Time.deltaTime; // Gravity pulls backward in Z
            transform.position += new Vector3(0, 0, velocity.z * Time.deltaTime);
        }
    }

    void ClampPosition()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
        transform.position = pos;
    }

    void CheckGrounded()
    {
        float halfWidth = transform.localScale.x / 2f;
        Vector3 origin = transform.position;

        Vector3 leftOrigin = origin + Vector3.left * halfWidth;
        Vector3 rightOrigin = origin + Vector3.right * halfWidth;

        bool leftHit = Physics.Raycast(leftOrigin, Vector3.back, groundCheckDistance, groundLayer);
        bool rightHit = Physics.Raycast(rightOrigin, Vector3.back, groundCheckDistance, groundLayer);

        isGrounded = leftHit || rightHit;

        if (isGrounded && velocity.z < 0f)
        {
            velocity.z = 0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("2d") || collision.gameObject.CompareTag("Spike"))
        {
            switchManager.deathscreen();
        }
    }

    public void kill()
    {
        switchManager.deathscreen();
    }
}
