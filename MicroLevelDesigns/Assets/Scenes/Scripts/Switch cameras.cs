using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

public class Switchcameras : MonoBehaviour
{
    public GameObject threedcam;

    public GameObject twodcam;
    public GameObject player;
    bool b3d=true;
    public float angularSpeed = 1f;
    public float circleRad = 1f;

    private Vector3 perpendicular;
    private Vector3 fixedPoint;
    private float currentAngle;
    

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        fixedPoint = player.transform.position;

    }

    
    // Update is called once per frame
    void Update()
    {
        ChangeCamera();
        if (b3d)
        {
            Move3dCAmera();
        }
        else
        {
            /*Move2dcamera();
            planemaker();*/
        }

    }

    private void planemaker()
    {
        RaycastHit hit;
        if (Physics.Raycast(twodcam.transform.position, twodcam.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(twodcam.transform.position, twodcam.transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            //Debug.Log(hit.point);
        }
        perpendicular = player.transform.position - twodcam.transform.position;
        
        

    }

    private void Move2dcamera()
    {
        twodcam.transform.LookAt(player.transform);
    }

    void ChangeCamera()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("hit");
            /*if (b3d)
            {
                threedcam.SetActive(false);
                twodcam.SetActive(true);

            }
            else
            {
                threedcam.SetActive(true);
                twodcam.SetActive(false);

            }*/
            b3d = !b3d;
            threedcam.SetActive(b3d);
            twodcam.SetActive(!b3d);
            
        }
    }

    private void Move3dCAmera()
    {
       threedcam.transform.LookAt(player.transform);
       if (Input.GetMouseButton(0))
       {
           
           {
               Debug.Log("mouse1");
               currentAngle += angularSpeed * Time.deltaTime;
                offset = new Vector3 (Mathf.Sin(currentAngle),0,Mathf.Cos((currentAngle))) * circleRad;
               threedcam.transform.position = fixedPoint + offset;
           }
          
       }

       if (Input.GetMouseButton(1))
           
       {
           {
               Debug.Log("mouse0");
               currentAngle -= angularSpeed * Time.deltaTime;
               offset = new Vector3 (Mathf.Sin (currentAngle), 0, Mathf.Cos (currentAngle)) * circleRad;
               threedcam.transform.position = fixedPoint + offset;
           }
       }
    }

    
}
