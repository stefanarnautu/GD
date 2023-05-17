using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelMenu : MonoBehaviour
{
    private MemoriseTheLevel mLevel;


    private void Start()
    {
        mLevel = FindObjectOfType<MemoriseTheLevel>();
        if (mLevel == null)
        {
            Debug.LogError("MemoriseTheLevel script not found in the scene.");
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        if (mLevel != null)
        {
            SceneManager.LoadScene(mLevel.Level);
        }
    }

    public void NextLevel()
    {
        if (mLevel != null)
        {
            mLevel.Level++;
            int sceneIndex = mLevel.Level;
            if (sceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(sceneIndex);
            }
            else
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
