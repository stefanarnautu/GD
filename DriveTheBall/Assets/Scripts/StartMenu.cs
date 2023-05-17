using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public int levell;
    private MemoriseTheLevel mLevel;

    private void Start()
    {
        mLevel = FindObjectOfType<MemoriseTheLevel>();
        if (mLevel == null)
        {
            Debug.LogError("MemoriseTheLevel script not found in the scene.");
        }
    }

    public void StartTheGame()
    {
        if (mLevel != null)
        {
            mLevel.Level = levell+2;
            SceneManager.LoadScene(mLevel.Level);
        }
    }

    public void GoToChooseLevel()
    {
        if (mLevel != null)
        {
            mLevel.Level = 1;
            SceneManager.LoadScene(mLevel.Level);
        }
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene(8);
    }
}
