using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class New3dplayer : MonoBehaviour
{
    
    [SerializeField]private GameObject player;

    [SerializeField]private float speed;
    [SerializeField]private GameObject othergaem;
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
    public void swap()
    {
        Debug.Log("hi");
        othergaem.SetActive(true);
        othergaem.transform.position =new Vector3(transform.position.x,othergaem.transform.position.y,transform.position.z);
        this.gameObject.SetActive(false);
    
    }

   public void kill()
    {
       
            Destroy(othergaem);
            Destroy(this.gameObject);
        
    }
}
