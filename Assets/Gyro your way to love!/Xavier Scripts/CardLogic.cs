using System;
using TMPro;
using UnityEngine;

namespace Gyro_your_way_to_love_.Xavier_Scripts
{
    public class CardLogic : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI tmp;
        public bool isMouseOver = false;
        private void OnMouseOver()
        {
            isMouseOver = true;
        }
        private void OnMouseExit()
        {
            isMouseOver = false;
        }
        public void InduceRight()
        {
            tmp.text = "You have swiped right!";
        }
        public void InduceLeft()
        {
            tmp.text = "You have swiped left!";
        }
    }
}