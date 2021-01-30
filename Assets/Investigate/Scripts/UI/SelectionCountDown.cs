using UnityEngine;

namespace Investigate.UI
{
    public class SelectionCountDown : MonoBehaviour
    {
        [SerializeField]
        private ComponentSelectionUI _componentSelectionUI;

        public void OnTimesUp()
        {
            _componentSelectionUI.CancelComponent();
        }
    }
}
