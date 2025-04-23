using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class SwitchManager : MonoBehaviour
{
    public Camera cam3d;
    public Camera cam2d;
    public GameObject[] objects3d;
    public GameObject[] objects2d;
    private new2denemy scripts2d;
    private New3dplayer scripts3d;
    bool b3d = true;
    public GameObject player3d;

    public GameObject player2d;
    [SerializeField]private GameObject nextlevel;
    [SerializeField] private GameObject uideathscreen;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void deathscreen()
    {
        uideathscreen.SetActive(true);   
        Debug.Log("deathscreen");
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void respawncharacter()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objects3d.Length != 0)
        {
            if (objects2d[0] == null || objects3d[0] == null)
     
            {
                nextlevel.SetActive(true);
            }
        }
       
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E");
            swictch();
        }
    }

    void swictch()
    {
        if (b3d)
        {
            cam3d.orthographic = false;
            player2d.SetActive(true);
            player2d.transform.position = player3d.transform.position;
            player3d.SetActive(false);
        }
        else
        {
            cam3d.orthographic = true;
            player3d.SetActive(true);
            player3d.transform.position = player2d.transform.position;
            player2d.SetActive(false);
        }

        for (int i = 0; i < objects3d.Length; i++)
        {
            if (b3d)
            {
                if (objects2d[i] != null)
                {
                    scripts2d = objects2d[i].GetComponent<new2denemy>();
                    if (scripts2d != null)
                        scripts2d.swap();
                }
            }
            else
            {
                if (objects3d[i] != null)
                {
                    scripts3d = objects3d[i].GetComponent<New3dplayer>();
                    if (scripts3d != null)
                        scripts3d.swap();
                }
            }
            
            
        }
       
       

        b3d = !b3d;
    }
}
