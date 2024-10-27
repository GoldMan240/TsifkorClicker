using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Code
{
    public class FloatingTextView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void SetText(string text) => 
            _text.text = text;
    }
}