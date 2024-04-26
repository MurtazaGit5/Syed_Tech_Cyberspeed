using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    public GameObject Card;
    public Data _data;

    // Start is called before the first frame update
    void Awake()
    {
        GenerateCards();
    }
   
    void GenerateCards()
    {
        int totalcard = _data.rows * _data.columns;

        for (int i = 0; i < totalcard; i++)
        {
            GameObject card = Instantiate(Card, this.transform);
            card.transform.name = "Card_" + i.ToString();
        }

    }
}