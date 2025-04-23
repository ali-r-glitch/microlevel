using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    private float moveSpeed = 18f;
    public SwitchManager switchManager;

    // Clamp bounds (adjust to fit your level size)
    private float minX = -87f;
    private float maxX = 15f;
    private float minZ = 59f;
    private float maxZ = 163f;

    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right arrows
        float moveZ = Input.GetAxisRaw("Vertical");   // W/S or Up/Down arrows

        Vector3 moveDir = new Vector3(moveX, 0f, moveZ).normalized;
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        ClampPosition();
    }

    private void ClampPosition()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);
        transform.position = pos;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("3d") || other.gameObject.CompareTag("Spike"))
        {
            switchManager.deathscreen();
        }
    }
}
