using System;
using Cinemachine;
using Investigate.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Investigate
{
    public class GameplayManager : MonoBehaviour
    {
        public static GameplayManager Instance { get; private set; }
        public bool isPausing { get; private set; }

        [SerializeField]
        private SFXManager _sfxManager;
        [SerializeField]
        private ComponentSelectionUI _componentSelectionUI = null;
        [SerializeField]
        private CloseSceneCurtain _closeSceneCurtain = null;
        [SerializeField]
        private GameObject _maskUI = null;
        [SerializeField]
        private CinemachineBrain _cinemachine;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            Time.timeScale = 1.0f;
        }

        public void SelectComponent(PartnerData data)
        {
            _componentSelectionUI.SetComponentSprite(data);
            // The game will resume after the component is selected
            GamePause();
        }

        public void GamePause()
        {
            _cinemachine.m_UpdateMethod = CinemachineBrain.UpdateMethod.LateUpdate;
            Time.timeScale = 0.0f;
            isPausing = true;
        }

        public void GameResume()
        {
            _cinemachine.m_UpdateMethod = CinemachineBrain.UpdateMethod.SmartUpdate;
            Time.timeScale = 1.0f;
            isPausing = false;
        }

        public void SwitchToBattle()
        {
            GamePause();
            _sfxManager.SwitchToBattleBGM();
            _maskUI.SetActive(false);
            _closeSceneCurtain.CloseCurtain(() =>
                SceneManager.LoadScene("MainBattle"));
        }
    }
}
