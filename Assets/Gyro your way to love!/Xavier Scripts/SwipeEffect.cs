using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeEffect : MonoBehaviour,IBeginDragHandler,IDragHandler, IEndDragHandler
{
   private Vector3 _initialPos;
   private float _distanceMoved;
   private bool _swipeLeft;
   private Instantiator _instantiator;
   public event Action cardMoved;

   private void Start()
   {
      _instantiator = FindObjectOfType<Instantiator>();
   }

   public void OnDrag(PointerEventData eventData)
   {
      transform.localPosition = new Vector2(transform.localPosition.x + eventData.delta.x, transform.localPosition.y);

      if (transform.localPosition.x - _initialPos.x > 0)
      {
         //Swipe Right
         transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0, -30, 
               (_initialPos.x + transform.localPosition.x)/(Screen.width/2)));
      }
      else
      {
         // Swipe Left
         transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0, 30, 
            (_initialPos.x - transform.localPosition.x)/(Screen.width/2)));
      }
   }

   public void OnBeginDrag(PointerEventData eventData) // Plenty of interface uses!
   {
      _initialPos = transform.localPosition;
   }

   public void OnEndDrag(PointerEventData eventData)
   {
      _distanceMoved = Mathf.Abs(transform.localPosition.x - _initialPos.x);
      if (_distanceMoved < 0.4 * Screen.width)
      {
         transform.localPosition = _initialPos;   
      }
      else
      {
         if (transform.position.x > _initialPos.x) // checking is the position is greater than.
         {
            _swipeLeft = false;
         }
         else
         {
            _swipeLeft = true;
         }

         cardMoved?.Invoke(); // If its moved! we invoke the event.
         StartCoroutine(MoveCard()); // Unity event!
      }
   }

   private IEnumerator MoveCard()
   {
      float time = 0;
      // This just gets color... Nothing important
      while (GetComponent<RawImage>().color != new Color(1, 1, 1, 0))
      {
         // we get the time of the game itself.
         time += Time.deltaTime;
         if (_swipeLeft) // if true
         {
            transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x,
               transform.localPosition.x - Screen.width,time),transform.localPosition.y,0);
         }
         else
         {
            transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x,
               transform.localPosition.x + Screen.width,time),transform.localPosition.y,0);
         }
         GetComponent<RawImage>().color = new Color(1, 1, 1, Mathf.SmoothStep(1, 0, 4*time));
         yield return null;
      }
      _instantiator.DestroyOnSwipe(gameObject); // Then we call the function in another script!
   }
}
