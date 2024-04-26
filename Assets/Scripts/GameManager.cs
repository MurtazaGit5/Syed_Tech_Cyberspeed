using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Card;
    public int rows;
    public int colums;
    public Transform Grid_Parent;
    // Start is called before the first frame update
    void Awake()
    {
        GenerateCards();
    }

    void Start()
    {
        
    }
    void GenerateCards()
    {
        int totalcard = rows * colums;

        for (int i = 0; i < totalcard; i++)
        {
            GameObject card = Instantiate(Card, Grid_Parent.transform);
            card.transform.name = "Card_" + i.ToString();
        }


    }
}
