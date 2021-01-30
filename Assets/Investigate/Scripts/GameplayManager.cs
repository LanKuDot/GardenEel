﻿using Cinemachine;
using Investigate.UI;
using UnityEngine;

namespace Investigate
{
    public class GameplayManager : MonoBehaviour
    {
        public static GameplayManager Instance { get; private set; }
        public bool isPausing { get; private set; }

        [SerializeField]
        private ComponentSelectionUI _componentSelectionUI = null;
        [SerializeField]
        private CinemachineBrain _cinemachine;

        private void Awake()
        {
            Instance = this;
        }

        public void SelectComponent(PartnerData data)
        {
            _componentSelectionUI.SetComponentSprite(
                data.componentType, data.componentSprite, data.id);
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
    }
}