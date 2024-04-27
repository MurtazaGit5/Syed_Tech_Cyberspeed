using UnityEngine;

[System.Serializable]
public struct PlayerData
{
    public string playername;
    public int playerscore;
}

[CreateAssetMenu(fileName = "GameScoreData", menuName = "Game/Score")]
public class Scoring : ScriptableObject
{
    public PlayerData[] Player;
}
