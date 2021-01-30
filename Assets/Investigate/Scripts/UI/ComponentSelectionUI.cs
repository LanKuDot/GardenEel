using UnityEngine;
using UnityEngine.UI;

namespace Investigate.UI
{
    public class ComponentSelectionUI : MonoBehaviour
    {
        [SerializeField]
        private Image[] _componentImages = null;
        [SerializeField]
        private GameObject _checkUI = null;
        [SerializeField]
        private Image _targetComponent = null;
        [SerializeField]
        private Text _lastWordText = null;
        [SerializeField]
        private Text _skillExplainText = null;

        private GardenEel.BodyType _candidateType;
        private Sprite _candidateSprite;
        private int _candidateComponentID;

        public void SetComponentSprite(PartnerData data)
        {
            _candidateType = data.componentType;
            _candidateSprite = data.componentSprite;
            _candidateComponentID = data.id;

            _targetComponent.sprite = _candidateSprite;
            _lastWordText.text = data.lastWordStr;
            _skillExplainText.text = data.skillExplainStr;

            _checkUI.SetActive(true);
        }

        public void ConfirmComponent()
        {
            var targetSlotID =
                GardenEelComponent.Instance.SetComponent(
                    _candidateComponentID, out var toAppend);
            AppendSprite(targetSlotID, toAppend);

            _checkUI.SetActive(false);
            GameplayManager.Instance.GameResume();
        }

        public void CancelComponent()
        {
            _checkUI.SetActive(false);
            GameplayManager.Instance.GameResume();
        }

        private void AppendSprite(int targetSlotID, bool toAppend)
        {
            if (toAppend) {
                for (var i = 1; i < _componentImages.Length; ++i)
                    _componentImages[i - 1].sprite = _componentImages[i].sprite;
            }

            _componentImages[targetSlotID].sprite = _candidateSprite;
        }
    }
}
