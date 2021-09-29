using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gyro_your_way_to_love_.Xavier_Scripts
{
    public class LogicGame : MonoBehaviour
    {
        [Header("--Setup--")]
        public GameObject card;
        public CardLogic cl;
        private RawImage rI;
        [Header("--Settings--")]
        [SerializeField] float fMovingspeed = 1;

        // Start is called before the first frame update
        void Start()
        {
            rI = card.GetComponent<RawImage>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0) && cl.isMouseOver)
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                card.transform.position = pos;
            }
            else
            {
                card.transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), fMovingspeed);
            }
            //checking the side
            if (card.transform.position.x > 2)
            {
               //rI.color = Color.green;
                if (Input.GetMouseButton(0))
                {
                    cl.InduceRight();
                }
            }
            else if (card.transform.position.x < -2)
            {
                //rI.color = Color.red;
                if (Input.GetMouseButton(0))
                {
                    cl.InduceLeft();
                }
            }
            // else
            // {
            //     rI.color = Color.white;
            // }
        }
    }
}