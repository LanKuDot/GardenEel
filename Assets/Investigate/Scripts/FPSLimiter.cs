using UnityEngine;

namespace Investigate
{
    public class FPSLimiter : MonoBehaviour
    {
        public int fps = 60;

        private void Start()
        {
            Application.targetFrameRate = fps;
        }
    }
}
