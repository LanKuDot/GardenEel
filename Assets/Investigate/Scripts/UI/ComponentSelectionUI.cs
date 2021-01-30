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
            _componentImages[(int) _candidateType].sprite = _candidateSprite;
            GardenEelComponent.Instance.SetComponent(
                _candidateType, _candidateComponentID);

            _checkUI.SetActive(false);
            GameplayManager.Instance.GameResume();
        }

        public void CancelComponent()
        {
            _checkUI.SetActive(false);
            GameplayManager.Instance.GameResume();
        }
    }
}
