using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardSpawner : MonoBehaviour
{
    [SerializeField] GameObject Card;
    private GridLayoutGroup GridGroup;


    void Start()
    {
        GenerateCards();
        GridLaoutSetting();
    }

    void GenerateCards()
    {
        int totalCard = GameManager.instance._data.rows * GameManager.instance._data.columns;
        int numPairs = totalCard / 2;

        List<Sprite> selectedImages = new List<Sprite>();

        // Select unique images for each pair
        for (int i = 0; i < numPairs; i++)
        {
            // Select a random image from available images
            Sprite randomImage = GetUniqueImage(selectedImages);

            // Add this image twice (for pair)
            selectedImages.Add(randomImage);
            selectedImages.Add(randomImage);
        }

        // Shuffle the selected images
        Shuffle(selectedImages);

        // Instantiate cards and assign shuffled images
        for (int i = 0; i < totalCard; i++)
        {
            GameObject card = Instantiate(Card, this.transform);
            card.transform.name = "Card_" + i.ToString();

            // Set the sprite of the child image component
            Image cardImage = card.transform.GetChild(0).GetComponent<Image>();
            cardImage.sprite = selectedImages[i];

            card.transform.GetChild(0).name = card.transform.GetChild(0).GetComponent<Image>().sprite.name;
        }
    }

    Sprite GetUniqueImage(List<Sprite> selectedImages)
    {
        Sprite randomImage;
        do
        {
            // Select a random image from available images
            randomImage = GameManager.instance.card_images[Random.Range(0, GameManager.instance.card_images.Length)];
        }
        // Check if this image is already selected
        while (selectedImages.Contains(randomImage));

        return randomImage;
    }

    void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    void GridLaoutSetting()
    {
        GridGroup = GetComponent<GridLayoutGroup>();
        GridGroup.constraintCount = GameManager.instance._data.columns;

        if (GameManager.instance._data.columns >= 6)
            GridGroup.cellSize = new Vector2(160,160);
        else
            GridGroup.cellSize = new Vector2(200, 200);
    }
}