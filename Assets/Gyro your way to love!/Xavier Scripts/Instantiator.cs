using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public GameObject cardPrefab;

    void InstantiateCard()
    {
        GameObject newCard = Instantiate(cardPrefab, transform, false);
        newCard.transform.SetAsFirstSibling();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (transform.childCount < 2)
        {
             InstantiateCard();
        }
    }
}
