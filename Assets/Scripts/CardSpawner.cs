using UnityEngine;
using UnityEngine.UI;
public class CardSpawner : MonoBehaviour
{
    [SerializeField] GameObject Card;
    [SerializeField] Data _data;
    private GridLayoutGroup GridGroup;
    void Awake()
    {
        GenerateCards();
        GridLaoutSetting();
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

    void GridLaoutSetting()
    {
        GridGroup = GetComponent<GridLayoutGroup>();
        GridGroup.constraintCount = _data.columns;

        if (_data.columns >= 6)
            GridGroup.cellSize = new Vector2(160,160);
        else
            GridGroup.cellSize = new Vector2(200, 200);
    }
}