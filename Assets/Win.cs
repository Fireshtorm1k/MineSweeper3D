using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public static TMP_Text text;

    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GridManager.correctNumber == GridManager.mineCount)
        {
            text.alpha = 255f;
        }
        else
        {
            text.alpha = 0f;
        }
    }
}
