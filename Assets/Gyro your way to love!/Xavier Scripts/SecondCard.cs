using System;
using System.Security.Cryptography;
using UnityEngine;

namespace Gyro_your_way_to_love_.Xavier_Scripts
{
    public class SecondCard : MonoBehaviour
    {
        private SwipeEffect _swipeEffect;

        private GameObject _secondCard;

        // private void Start()
        // {
        //     //_swipeEffect = FindObjectOfType<SwipeEffect>();
        //     _secondCard = _secondCard.gameObject;
        //     _swipeEffect.cardMoved += CardMoveFront;
        //     transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        // }

        // private void Update()
        // {
        //     float distanceMoved = _secondCard.transform.localPosition.x;
        //     if (Mathf.Abs(distanceMoved) > 0)
        //     {
        //         float step = Mathf.SmoothStep(0.8f, 1, Mathf.Abs(distanceMoved) / (Screen.width / 2));
        //         transform.localScale = new Vector3(step, step, step);
        //     }
        // }

        private void CardMoveFront()
        {
            gameObject.AddComponent<SwipeEffect>();
            Destroy(this);
        }
    }
}