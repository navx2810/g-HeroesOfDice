using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TextAlert : MonoBehaviour
{
    [SerializeField]
    private Text a, b;

    private bool isShowing = false;
    private List<String> _messageQueue; 

    public void Awake()
    {
        _messageQueue = new List<string>();
    }

    public void SetText(string message, float duration)
    {
        _messageQueue.Add(message);

        if (!isShowing) StartCoroutine(ShowText(1f));
    }

    public void SetText(string message)
    {
        SetText(message, 2f);
    }

    public void ShowEndMessage(string message)
    {
        StopAllCoroutines();
        StartCoroutine(ShowEnd(message));
    }

    IEnumerator ShowText(float duration)
    {
        while (_messageQueue.Count != 0)
        {
            a.text = _messageQueue.First();
            b.text = _messageQueue.First();

            _messageQueue.Remove(_messageQueue.First());

            yield return new WaitForSeconds(duration);
        }

        a.text = "";
        b.text = "";

        isShowing = false; 

    }

    IEnumerator ShowEnd(string m)
    {
        a.text = m;
        b.text = m;

        yield return new WaitForSeconds(2f);

        Application.Quit();
        Application.LoadLevel(Application.loadedLevel);
    }
}
