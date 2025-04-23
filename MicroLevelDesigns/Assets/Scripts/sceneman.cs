using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneman : MonoBehaviour
{
    public string sceneNa;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            LoadSceneByName(sceneNa);
        }
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Load next scene in build index
    public void LoadNextScene()
    {
        int nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1) % 2;
        SceneManager.LoadScene(nextSceneIndex);
    
    }
}
