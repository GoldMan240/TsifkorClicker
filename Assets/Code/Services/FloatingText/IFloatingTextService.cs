using System;
using UnityEngine;

namespace Code
{
    public interface IFloatingTextService
    {
        void SetupText(string text, Vector3 startPosition, Vector3 endPosition, Action onPositionReached);
    }
}