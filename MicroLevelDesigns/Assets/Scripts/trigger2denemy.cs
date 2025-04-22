using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class trigger2denemy : MonoBehaviour
{
    
    GameObject parentenemy;
    private new2denemy scripts2d;

    private void Awake()
    {
        scripts2d = GetComponentInParent<new2denemy>();

    }

    // Start is called before the first frame update
    private void OnTriggerExit(Collider other)
    {
        scripts2d.isgrounde = false;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        scripts2d.isgrounde = true;
    }

   
}
