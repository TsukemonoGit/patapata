using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Clear : MonoBehaviour
{
    [SerializeField]
    private TMP_Text clearText;
    private int length;
    private int nowLength;
    int maxVisibleCharacters;
    private void Start()
    {
        clearText = GetComponent<TMP_Text>();
        length = clearText.text.Length;
        this.gameObject.SetActive(false);

    }

    public void ClearMovie()
    {
        nowLength = 0;
        StartCoroutine(ClearMove());
    }

    IEnumerator ClearMove()
    {
        for (int i = 0; i < length; i++)
        {
            nowLength++;
            clearText.maxVisibleCharacters = nowLength;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.1f);
        this.gameObject.SetActive(false);
    }
}
