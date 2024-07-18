using System;

[Serializable]
public class SaveData
{
    public int CurrentSceneID;

    public void Reset()
    {
        CurrentSceneID = 0;
    }
}
