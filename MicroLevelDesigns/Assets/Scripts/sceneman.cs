using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneman : MonoBehaviour
{
 

    public string sceneToLoad;
    public EntranceID entranceUsed;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.lastEntrance = entranceUsed;
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextScene()
    {
        int nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }
}