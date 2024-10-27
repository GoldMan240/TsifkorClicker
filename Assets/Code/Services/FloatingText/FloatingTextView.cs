using TMPro;
using UnityEngine;

namespace Code.Services.FloatingText
{
    public class FloatingTextView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        public void SetText(string text) => 
            _text.text = text;
    }
}