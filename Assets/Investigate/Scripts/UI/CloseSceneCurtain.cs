using System;
using UnityEngine;

namespace Investigate.UI
{
    public class CloseSceneCurtain : MonoBehaviour
    {
        private Action _curtainClosedCallback;

        public void CloseCurtain(Action callback)
        {
            gameObject.SetActive(true);
            _curtainClosedCallback = callback;
        }

        public void OnCurtainClosed()
        {
            _curtainClosedCallback?.Invoke();
        }
    }
}
