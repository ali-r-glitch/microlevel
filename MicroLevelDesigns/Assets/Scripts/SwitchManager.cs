using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SwitchManager : MonoBehaviour
{
    public Camera cam3d;
    public Camera cam2d;
    public GameObject[] objects3d;
    public GameObject[] objects2d;
    private new2denemy scripts2d;
    private New3dplayer scripts3d;
    bool b3d=true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E");
            swictch();
        }
    }

    void swictch()
    {
        for (int i = 0; i < objects3d.Length; i++)
        {
            if (b3d)
            {
                cam3d.orthographic = false;
                /*cam3d.enabled = false;
                cam2d.enabled = true;
                */
                scripts2d= objects2d[i].GetComponent<new2denemy>();
                scripts2d.swap();
            }
            else
            {
                cam3d.orthographic = true;
                /*cam2d.enabled = false;
                cam3d.enabled = true;
                */
                scripts3d= objects3d[i].GetComponent<New3dplayer>();
                scripts3d.swap();
            }
            
        }

        b3d = !b3d;
    }
}
