using UnityEngine;
using UnityEngine.UI;

namespace Investigate.UI
{
    public class ComponentSelectionUI : MonoBehaviour
    {
        public static ComponentSelectionUI Instance { get; private set; }

        [SerializeField]
        private Image[] _componentImages = null;
        [SerializeField]
        private GameObject _checkUI = null;
        [SerializeField]
        private Image _targetComponent = null;

        private GardenEel.BodyType _candidateType;
        private Sprite _candidateSprite;
        private int _candidateComponentID;

        private void Awake()
        {
            Instance = this;
        }

        public void SetComponentSprite(
            GardenEel.BodyType type, Sprite sprite, int componentID)
        {
            _candidateType = type;
            _candidateSprite = sprite;
            _candidateComponentID = componentID;

            _targetComponent.sprite = sprite;
            _checkUI.SetActive(true);
        }

        public void ConfirmComponent()
        {
            _componentImages[(int) _candidateType].sprite = _candidateSprite;
            GardenEelComponent.Instance.SetComponent(
                _candidateType, _candidateComponentID);

            _checkUI.SetActive(false);
        }

        public void CancelComponent()
        {
            _checkUI.SetActive(false);
        }
    }
}
