using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    private Slider slidToText;
   [SerializeField] private TMP_Text _text;
   [SerializeField] private string _nameof;

    void Start()
    {
      slidToText = GetComponentInParent<Slider>();
      _text = GetComponent<TMP_Text>();
    }
    void Update()
    {
        _text.text =_nameof + slidToText.value.ToString();
    }
}
