using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Game/Data")]
public class Data : ScriptableObject
{
    public int rows;
    public int columns;

    public string Current_Card_Name;
    public string Last_Card_Name;

    public string Defficulty_Level;
}
