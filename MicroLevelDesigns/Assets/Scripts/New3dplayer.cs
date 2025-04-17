using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class New3dplayer : MonoBehaviour
{
    
    [SerializeField]private GameObject player;

    [SerializeField]private float speed;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position=Vector3.MoveTowards(transform.position,player.transform.position,speed);
    }
}
