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

   public event Action cardMoved;
   
   public void OnDrag(PointerEventData eventData)
   {
      transform.localPosition = new Vector2(transform.localPosition.x + eventData.delta.x, transform.localPosition.y);

      if (transform.localPosition.x - _initialPos.x > 0)
      {
         transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0, -30, 
               (_initialPos.x + transform.localPosition.x)/(Screen.width/2)));
      }
      else
      {
         transform.localEulerAngles = new Vector3(0, 0, Mathf.LerpAngle(0, -30, 
            (_initialPos.x - transform.localPosition.x)/(Screen.width/2)));
      }
   }

   public void OnBeginDrag(PointerEventData eventData)
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
         if (transform.position.x > _initialPos.x)
         {
            if (transform.position.x > _initialPos.x)
            {
               _swipeLeft = false;
            }
            else
            {
               _swipeLeft = true;
            }
            cardMoved?.Invoke();
            StartCoroutine(MoveCard());
         }
      }
   }

   private IEnumerator MoveCard()
   {
      float time = 0;
      while (GetComponent<RawImage>().color != new Color(1, 1, 1, 0))
      {
         time += Time.deltaTime;
         if (_swipeLeft)
         {
            transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x,
               transform.localPosition.x - Screen.width, 4*time), transform.localPosition.y, 0);
         }
         else
         {
            transform.localPosition = new Vector3(Mathf.SmoothStep(transform.localPosition.x,
               transform.localPosition.x + Screen.width, 4*time), transform.localPosition.y, 0);
         }

         GetComponent<RawImage>().color = new Color(1, 1, 1, Mathf.SmoothStep(1, 0, 4*time));
         yield return null;
      }
      Destroy(gameObject);
   }
}
