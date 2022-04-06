using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public void NextLevel()
    {
        LevelManager.Instance.level += 1;
        PlayerPrefs.SetInt("level", LevelManager.Instance.level);
        LevelManager.Instance.LoadScene();
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PrintAsd()
    {
        print("asd");
    }
}
