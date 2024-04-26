using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject MainMenu_Panel;
    [SerializeField] GameObject ChooseMode_Panel;
    [SerializeField] Data _data;

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
        SceneManager.LoadScene(1);
    }

    public void GoBackToMenu()
    {
        ChooseMode_Panel.SetActive(false);
        MainMenu_Panel.SetActive(true);
    }
}
