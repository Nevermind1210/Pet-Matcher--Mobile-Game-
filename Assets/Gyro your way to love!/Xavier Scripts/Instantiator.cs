using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Instantiator : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private List<GameObject> cardPrefabs = new List<GameObject>();
    [SerializeField] private string[] filePath;

    private void Start()
    {
        // We start the instantiaton of cards
        InstantiateCard();
    }

    public void DestroyOnSwipe(GameObject card)
    {
        for (int i = cardPrefabs.Count - 1; i > 0 ; i--)
        {
            if (cardPrefabs[i] == card)
            {
                GameObject obj = cardPrefabs[i];
                cardPrefabs.RemoveAt(i);
                Destroy(obj);
            }
        }
    }

    void InstantiateCard()
    {
        for (int i = 0; i < 6; i++)
        { 
            GameObject newCard = Instantiate(cardPrefab, transform, false);
            var image = newCard.GetComponent<RawImage>().texture =
                Resources.Load<Texture>(filePath[UnityEngine.Random.Range(0, filePath.Length)]);
            newCard.transform.SetAsFirstSibling();
            cardPrefabs.Add(newCard);
        }
    }
    
    // Update is called once per frame
    private void Update()
    {
        if (transform.childCount <= 2)
        {
            InstantiateCard();
        }
    }
}
