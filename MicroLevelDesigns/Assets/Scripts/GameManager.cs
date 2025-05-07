using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public HashSet<string> completedLevels = new HashSet<string>();
    public EntranceID? lastEntrance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void MarkLevelComplete(string sceneName)
    {
        if (!completedLevels.Contains(sceneName))
        {
            completedLevels.Add(sceneName);
        }
    }

    public bool IsLevelComplete(string sceneName)
    {
        return completedLevels.Contains(sceneName);
    }

}