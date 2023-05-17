using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GenerateScore : MonoBehaviour
{
    private int score = 0;
    private MemoriseTheLevel mLevel;
    [SerializeField]
    private TextMeshProUGUI textComponent;

    public int generateScore()
    {
        score++;
        return score;
    }

    private void Start()
    {
        
        mLevel = FindObjectOfType<MemoriseTheLevel>();
        if (mLevel == null)
        {
            Debug.LogError("MemoriseTheLevel script not found in the scene.");
        }
        if (textComponent != null && mLevel != null)
        {

            int maxPlatforms = mLevel.getLevelData(mLevel.Level - 3).maxPlatformFor100;
            int penalty = mLevel.getLevelData(mLevel.Level - 3).penalty;
            int scoreBasedOnLevel = mLevel.Platforms > maxPlatforms ? 100 - ((mLevel.Platforms - maxPlatforms) * penalty) : 100;

            if (scoreBasedOnLevel < 0)
            {
                textComponent.text = "0";
            }
            else
            {
                textComponent.text = scoreBasedOnLevel.ToString();
            }
            
           
            mLevel.Platforms = 0;
        }
    }

}