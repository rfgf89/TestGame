using System;

[Serializable]
public class PlayerData
{
    public float speedModify = 1.0f;
    public float currentTime;
    public float life = 3.0f;
    public float timeInLastLife;
    public GameMode gameMode = GameMode.Easy;
}