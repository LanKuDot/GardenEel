using UnityEngine;

namespace Functional
{
    public class SharkAnimation : MonoBehaviour
    {
        [SerializeField]
        private StorySceneManager _storySceneManager = null;

        public void SharkAnimationEnd()
        {
            _storySceneManager.ChangeBackground();
        }
    }
}
