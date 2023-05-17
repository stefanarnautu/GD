using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoriseTheLevel : MonoBehaviour
{
    private static int level=0;
    private static int platforms = 0;
    private LevelDatas[] levelsData = new LevelDatas[]
        {
            new LevelDatas(1, 4, 5),
            new LevelDatas(2, 10, 6),
            new LevelDatas(3, 6, 7),
            new LevelDatas(4, 7, 8),
            new LevelDatas(5, 50, 5),
            new LevelDatas(6, 8, 10),
            new LevelDatas(7, 9, 11),
            new LevelDatas(8, 10, 12)
        };

    public int Level
    {
        get { return level; }
        set {
            level = value; 
        }
    }

    public int Platforms
    {
        get { return platforms; }
        set
        {
            platforms = value;
        }
    }

    private void Start()
    {
       
    }

    public LevelDatas getLevelData(int index)
    {
        if (index >= 0 && index < levelsData.Length)
        {
            return levelsData[index];
        }
        else
        {
            Debug.LogError(index);
            Debug.LogError("Invalid index for accessing LevelDatas array.");
            return null;
        }
    }
}
