using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaneGridController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator gridAnimator;

    private void Awake()
    {
        gridAnimator = gameObject.GetComponent<Animator>();    
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gridAnimator.SetBool(Const.animatorIsBigger, true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gridAnimator.SetBool(Const.animatorIsBigger, false);
    }
}
