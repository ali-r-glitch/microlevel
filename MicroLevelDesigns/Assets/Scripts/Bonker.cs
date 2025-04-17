using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonker : MonoBehaviour
{
    private new2denemy scri2d;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            scri2d=GetComponentInParent<new2denemy>();
            scri2d.bonked();

        }
    }
}
