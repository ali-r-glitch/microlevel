using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
  

    // Update is called once per frame
    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right arrows
        float moveZ = Input.GetAxisRaw("Vertical");   // W/S or Up/Down arrows

        Vector3 moveDir = new Vector3(moveX, 0f, moveZ).normalized;
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
