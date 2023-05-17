using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDatas
{
    public int level;
    public int maxPlatformFor100;
    public int penalty;

    public LevelDatas(int levelValue, int maxPlatformValue, int penaltyValue)
    {
        level = levelValue;
        maxPlatformFor100 = maxPlatformValue;
        penalty = penaltyValue;
    }
}
