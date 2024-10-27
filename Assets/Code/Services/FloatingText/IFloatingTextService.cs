using System;
using UnityEngine;

namespace Code.Services.FloatingText
{
    public interface IFloatingTextService
    {
        void SetupText(string text, Vector3 startPosition, Vector3 endPosition, Action onPositionReached);
    }
}