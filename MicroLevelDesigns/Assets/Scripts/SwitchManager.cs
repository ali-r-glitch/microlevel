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
    public GameObject player3d;
    public GameObject player2d;
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
                player2d.SetActive(true);
                player2d.transform.position=player3d.transform.position;
                player3d.SetActive(false);
                
            }
            else
            {
                cam3d.orthographic = true;
                /*cam2d.enabled = false;
                cam3d.enabled = true;
                */
                scripts3d= objects3d[i].GetComponent<New3dplayer>();
                scripts3d.swap();
                player3d.SetActive(true);
                player3d.transform.position=player2d.transform.position;
                player2d.SetActive(false);
            }
            
        }

        b3d = !b3d;
    }
}
