using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class new2denemy : MonoBehaviour
{
    [SerializeField] private bool isgrounde;
    public Vector3 traveldir;
    public bool bright;

    [SerializeField]private float speed;
    // Start is called before the first frame update
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        traveldir = -transform.right;
        bright = false;
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isgrounde)
        {
            move();
        }

       

    }

    private void Update()
    {
        testdirection();
        
    }

    private void testdirection()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bright)
            {
                Debug.Log("left");
                traveldir = -transform.right;
            }
               
            else
            {
                Debug.Log("right");
                traveldir = transform.right;
            }
            bright = !bright;
        }
    }

    private void move()
    {
       transform.position += traveldir * speed*Time.deltaTime ;
        
    }

    public void bonked()
    {
        transform.Rotate(0, 0, 180);
        traveldir = transform.right;
    }

}
