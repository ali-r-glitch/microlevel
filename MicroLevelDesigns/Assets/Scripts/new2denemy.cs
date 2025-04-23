using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class new2denemy : MonoBehaviour
{
    [SerializeField] private float groundCheckDistance = 100.0f;
    [SerializeField] private LayerMask groundLayer;
  

    [SerializeField] public bool isgrounde=true;
    public Vector3 traveldir;
    public bool bright;
    [SerializeField]private GameObject othergaem;

    private float speed=19f;
    // Start is called before the first frame update
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        traveldir = -transform.right;
        bright = false;
    }

    public void kill()
    {
       
        Destroy(othergaem);
        Destroy(this.gameObject);
        
    }

    private void CheckGrounded()
    {
        Ray ray = new Ray(transform.position, Vector3.back);
        isgrounde = Physics.Raycast(ray, groundCheckDistance, groundLayer);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = isgrounde ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.back * groundCheckDistance);

        if (Physics.Raycast(transform.position, Vector3.back, out RaycastHit hitInfo, groundCheckDistance))
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(hitInfo.point, 0.1f);
        }
    }
    

    // Update is called once per frame
    private void FixedUpdate()
    {
        CheckGrounded();

        if (isgrounde)
        {
            
            move();
          
        }else
        {
            falling();
        }
       
         
        

       

    }

    private void falling()
    {
      transform.position+=Vector3.back*9.8f*Time.deltaTime;
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
       
            // Flip the direction manually
            traveldir.x *= -1f;

            // Flip the visual by flipping the scale
            Vector3 scale = transform.localScale;
            scale.x *= -1f;
            transform.localScale = scale;
        

    }

    public void swap()
    {
        Debug.Log("hi");
        Debug.Log("hi");
        othergaem.SetActive(true);
        othergaem.transform.position =new Vector3(transform.position.x,othergaem.transform.position.y,transform.position.z);
        this.gameObject.SetActive(false);
    }
}
