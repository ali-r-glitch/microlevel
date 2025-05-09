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
        // Show nextlevel immediately if level was already completed
        string currentScene = SceneManager.GetActiveScene().name;
        if (GameManager.Instance.IsLevelComplete(currentScene))
        {
            nextlevel.SetActive(true);
        }
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
    bool AllEnemiesDead()
    {
        foreach (GameObject obj in objects3d)
        {
            if (obj != null) return false;
        }

        foreach (GameObject obj in objects2d)
        {
            if (obj != null) return false;
        }

        return true;
    }


    // Update is called once per frame
    void Update()
    {
        if (AllEnemiesDead() && !nextlevel.activeSelf)
        {
            nextlevel.SetActive(true);
            string currentScene = SceneManager.GetActiveScene().name;
            GameManager.Instance.MarkLevelComplete(currentScene);
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
