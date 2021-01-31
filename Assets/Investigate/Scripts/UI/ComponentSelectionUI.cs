using UnityEngine;
using UnityEngine.UI;

namespace Investigate.UI
{
    public class ComponentSelectionUI : MonoBehaviour
    {
        #region Serialized Fields

        [SerializeField]
        private Image[] _componentImages = null;
        [SerializeField]
        private GameObject _checkUI = null;
        [SerializeField]
        private Animator _checkUIAnimator = null;
        [SerializeField]
        private Image _lastWordImage = null;
        [SerializeField]
        private Image _skillHintImage = null;
        [SerializeField]
        private Animator _skillHintAnimator = null;

        #endregion

        private Sprite _candidateSprite;
        private Sprite _candidateSkillHintSprite;
        private int _candidateComponentID;

        public void SetComponentSprite(PartnerData data)
        {
            _candidateSprite = data.componentSprite;
            _candidateComponentID = data.id;
            _candidateSkillHintSprite = data.skillHintSprite;

            _lastWordImage.sprite = data.lastWordSprite;

            _checkUI.SetActive(true);
            _checkUIAnimator.Play("CheckUIIn", -1, 0);
        }

        public void ConfirmComponent()
        {
            var targetSlotID =
                GardenEelComponent.Instance.SetComponent(
                    _candidateComponentID, out var toAppend);
            AppendSprite(targetSlotID, toAppend);

            _checkUI.SetActive(false);
            GameplayManager.Instance.GameResume();

            _skillHintImage.sprite = _candidateSkillHintSprite;
            _skillHintAnimator.gameObject.SetActive(true);
            _skillHintAnimator.Play("SkillHint", -1, 0);
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
