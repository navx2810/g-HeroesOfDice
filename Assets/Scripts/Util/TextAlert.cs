using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextAlert : MonoBehaviour
{
    [SerializeField]
    private Text a, b;

    private bool isShowing = false;

    public void Awake()
    {
        SetText("");
    }

    public void SetText(string message, float duration)
    {
        if (!isShowing) StartCoroutine(ShowText(message, duration));
        StartCoroutine(ShowText(message, duration));
    }

    public void SetText(string message)
    {
        SetText(message, 2f);
    }

    IEnumerator ShowText(string message, float duration)
    {
        a.text = message;
        b.text = message;

        yield return new WaitForSeconds(duration);

        a.text = "";
        b.text = "";

        isShowing = false;
    }
}
