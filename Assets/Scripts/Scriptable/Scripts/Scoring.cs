using UnityEngine;

[System.Serializable]
public struct PlayerData
{
    public string playername;       // name of the player store in scriptable and using when need highscore to show
    public int playerscore;         // score of the player store in scriptable and using when need highscore to show
}

[CreateAssetMenu(fileName = "GameScoreData", menuName = "Game/Score")]
public class Scoring : ScriptableObject
{
    public PlayerData[] Player;
}
