using System;
using UnityEngine;
using System.Collections;
using DG.Tweening;

public class EntityShelf : MonoBehaviour
{

    public bool IsShowing;
    public RectTransform PanelRect, SelfRect;
    public Vector3 HiddenPosition;

	// Use this for initialization
	void Start ()
	{
	    IsShowing = true;
	    SelfRect = GetComponent<RectTransform>();
	}
	

    public void Hide()
    {
        if (!IsShowing)
            return;

        SelfRect.DOLocalMove(HiddenPosition, .25f).SetEase(Ease.InExpo);
        IsShowing = false;
    }

    public void Show()
    {
        if (IsShowing)
            return;

        SelfRect.DOLocalMove(Vector3.zero, .25f).SetEase(Ease.OutExpo);
        IsShowing = true;

    }
}
