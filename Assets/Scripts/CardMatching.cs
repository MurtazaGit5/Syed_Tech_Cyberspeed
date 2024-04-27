using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardMatching : MonoBehaviour
{
    [SerializeField] GameObject BackFace_img;
    [SerializeField] GameObject FrontFace_img;

    public static int moves=0;
    void Start()
    {
        
    }

    public void OpenCard()
    {
        moves++;
        GameManager.instance.Moves_txt.text = "Moves : " + moves.ToString();

        GetComponent<Button>().interactable = false;
        GetComponent<Animator>().SetTrigger("flip");
    }

    //call this function from animator event trigger
    public void _ChangeCard_Anim_Trigger()
    {
        BackFace_img.SetActive(false);
        FrontFace_img.SetActive(true);

        if (GameManager.instance._data.Last_Card_Name == string.Empty)
        {
            GameManager.instance._data.Last_Card_Name = transform.GetChild(0).name;
            GameManager.instance.LastCard = transform.gameObject;
        }
        else
        {
            GameManager.instance._data.Current_Card_Name = transform.GetChild(0).name;
            GameManager.instance.CurrentCard = transform.gameObject;
            Invoke("CheckMatching",0.5f);
        }
    }

    void CheckMatching()
    {
        // if match both cards
        if(GameManager.instance._data.Last_Card_Name== GameManager.instance._data.Current_Card_Name)
        {
            GameManager.instance.GameComplete();

            Destroy(GameManager.instance.LastCard);
            Destroy(GameManager.instance.CurrentCard);


            DefaultSet();
        }
        else
        {
            GameManager.instance.Set_Flip_Back();
            DefaultSet();
        }
    }

    void DefaultSet()
    {
        GameManager.instance._data.Last_Card_Name = string.Empty;
        GameManager.instance.LastCard = null;
        GameManager.instance._data.Current_Card_Name = string.Empty;
        GameManager.instance.CurrentCard = null;
    }
}
