using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Data _data;
    [SerializeField] Scoring Playerdata;
    public Sprite[] card_images; // List of 15 images

    public GameObject Grid;

    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject GameComplete_Panel;
    [SerializeField] GameObject HighScore_Panel;
    [SerializeField] InputField EnterName_input;
    public Text Moves_txt;

    [HideInInspector]
    public GameObject CurrentCard;
    [HideInInspector]
    public GameObject LastCard;


    public AudioSource MatchingSound;
    public AudioSource MisMatchingSound;

    private void Awake()
    {
        if(instance==null)
         instance = this;

        CardMatching.moves = 0;
    }
    private void Start()
    {
        _data.Current_Card_Name = "";
        _data.Last_Card_Name = "";

        Moves_txt.text = "Moves : " + CardMatching.moves.ToString();
    }

    public void Set_Flip_Back()
    {
        MisMatchingSound.Play();

        CurrentCard.transform.GetChild(0).gameObject.SetActive(false);
        CurrentCard.transform.GetChild(1).gameObject.SetActive(true);

        LastCard.transform.GetChild(0).gameObject.SetActive(false);
        LastCard.transform.GetChild(1).gameObject.SetActive(true);

        CurrentCard.GetComponent<Button>().interactable = true;
        LastCard.GetComponent<Button>().interactable = true;

    }


    public void GameComplete()
    {
        MatchingSound.Play();
        if (Grid.transform.childCount <= 2)
        {
            GameComplete_Panel.SetActive(true);
            SetScoring();
        }
    }
    void SetScoring()
    {
        if (_data.Defficulty_Level == "veryeasy")
        {
            if (Playerdata.Player[0].playerscore < 100 - CardMatching.moves)
            {
                Playerdata.Player[0].playerscore = 100 - CardMatching.moves;
                HighScore_Panel.SetActive(true);
            }
        }
        else if (_data.Defficulty_Level == "easy")
        {
            if (Playerdata.Player[1].playerscore < 100 - CardMatching.moves)
            {
                Playerdata.Player[1].playerscore = 100 - CardMatching.moves;
                HighScore_Panel.SetActive(true);
            }
        }
        else if (_data.Defficulty_Level == "medium")
        {
            if (Playerdata.Player[2].playerscore < 100 - CardMatching.moves)
            {
                Playerdata.Player[2].playerscore = 100 - CardMatching.moves;
                HighScore_Panel.SetActive(true);
            }
        }
        else if (_data.Defficulty_Level == "hard")
        {
            if (Playerdata.Player[3].playerscore < 100 - CardMatching.moves)
            {
                Playerdata.Player[3].playerscore = 100 - CardMatching.moves;
                HighScore_Panel.SetActive(true);
            }
        }
        else if (_data.Defficulty_Level == "veryhard")
        {
            if (Playerdata.Player[4].playerscore < 100 - CardMatching.moves)
            {
                Playerdata.Player[4].playerscore = 100 - CardMatching.moves;
                HighScore_Panel.SetActive(true);
            }
        }
    }
    public void SetPlayerName()
    {
        if (_data.Defficulty_Level == "veryeasy")
        {
            Playerdata.Player[0].playername = EnterName_input.text;
        }
        else if (_data.Defficulty_Level == "easy")
        {
            Playerdata.Player[1].playername = EnterName_input.text;
        }
        else if (_data.Defficulty_Level == "medium")
        {
            Playerdata.Player[2].playername = EnterName_input.text;
        }
        else if (_data.Defficulty_Level == "hard")
        {
            Playerdata.Player[3].playername = EnterName_input.text;
        }
        else if (_data.Defficulty_Level == "veryhard")
        {
            Playerdata.Player[4].playername = EnterName_input.text;
        }
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void PauseGame()
    {
        PauseMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        PauseMenu.SetActive(false);
    }
    public void GoBackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
