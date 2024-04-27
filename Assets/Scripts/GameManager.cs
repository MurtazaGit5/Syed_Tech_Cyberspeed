using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Data _data;
    public Sprite[] card_images; // List of your 15 images

    [SerializeField] GameObject PauseMenu;

    public GameObject CurrentCard;
    public GameObject LastCard;

    private void Awake()
    {
        if(instance==null)
         instance = this;
    }
    private void Start()
    {
        _data.Current_Card_Name = "";
        _data.Last_Card_Name = "";

    }

    public void Set_Flip_Back()
    {
        CurrentCard.transform.GetChild(0).gameObject.SetActive(false);
        CurrentCard.transform.GetChild(1).gameObject.SetActive(true);

        LastCard.transform.GetChild(0).gameObject.SetActive(false);
        LastCard.transform.GetChild(1).gameObject.SetActive(true);

        CurrentCard.GetComponent<Button>().interactable = true;
        LastCard.GetComponent<Button>().interactable = true;


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
