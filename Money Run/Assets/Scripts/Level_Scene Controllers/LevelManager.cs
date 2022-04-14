using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public int level;
    public bool isLoaderScene;
    public int wallet;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            level = PlayerPrefs.GetInt("level", 0);
        }
        else
        {
            Destroy(this);
        }

        if (isLoaderScene)
        {
            LoadScene();
        }
    }

    public void LoadScene()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings - 1;
        int loadScene = (level % sceneCount) + 1;
        print(loadScene);
        SceneManager.LoadSceneAsync(loadScene);
    }
}
