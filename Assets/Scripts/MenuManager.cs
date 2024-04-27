using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenu_Panel;
    [SerializeField] GameObject ChooseMode_Panel;
    [SerializeField] Data _data;
    [SerializeField] Scoring _playerdata;

    public Text[] NameofPerson;
    public Text[] ScoreofPerson;

    private void Start()
    {
        GetHighScoreData(); // get high score data from scriptable 
    }
    public void StartNewGame()
    {
        ChooseMode_Panel.SetActive(true);
        MainMenu_Panel.SetActive(false);
    }
    public void SetRow(int row)
    {
        _data.rows = row;
    }
    public void SetCoumn(int col)
    {
        _data.columns = col;
    }

    //i make difficulty string in scripbtable for differentiate between multiple matrix
    public void SetDifficulty_Name(string diff)
    {
        _data.Defficulty_Level = diff;
        SceneManager.LoadScene(1);
    }

    //show high score data
    void GetHighScoreData()
    {
        for (int i = 1; i <= _playerdata.Player.Length; i++)
        {
            NameofPerson[i].text = _playerdata.Player[i-1].playername;
            ScoreofPerson[i].text = _playerdata.Player[i - 1].playerscore.ToString() ;
        }
    }
    public void GoBackToMenu()
    {
        ChooseMode_Panel.SetActive(false);
        MainMenu_Panel.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit(0);
    }
}
