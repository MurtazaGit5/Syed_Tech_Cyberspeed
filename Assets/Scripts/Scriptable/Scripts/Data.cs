using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Game/Data")]
public class Data : ScriptableObject
{
    public int rows;        // set row according to user need
    public int columns;     // set columns according to user need

    // this is for matching purpose to compare the last and current card name
    public string Current_Card_Name;        
    public string Last_Card_Name;

    // this is for differntiate between different matrix set
    public string Defficulty_Level;
}
