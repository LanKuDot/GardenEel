using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Functional
{
    public class StorySceneManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _audioObject = null;
        [SerializeField]
        private Image _backgroundImage = null;
        [SerializeField]
        private Image _textImage = null;
        [SerializeField]
        private Vector2 _nextImagePos = Vector2.zero;
        [SerializeField]
        private Sprite _secondBackgroundSprite = null;
        [SerializeField]
        private Sprite _secondTextSprite = null;
        [SerializeField]
        private GameObject _characterObject = null;
        [SerializeField]
        private GameObject _deadBodyObject = null;

        private void Awake()
        {
            DontDestroyOnLoad(_audioObject);
        }

        public void ChangeBackground()
        {
            _backgroundImage.sprite = _secondBackgroundSprite;
            _textImage.sprite = _secondTextSprite;
            _textImage.rectTransform.anchoredPosition = _nextImagePos;
            _characterObject.SetActive(true);
            _deadBodyObject.SetActive(false);
            StartCoroutine(CountDown());
        }

        private IEnumerator CountDown()
        {
            yield return new WaitForSeconds(5.0f);
            SceneManager.LoadScene("Tutorial");
        }
    }
}
