using UnityEngine;

namespace Investigate
{
    public class SFXManager : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _bgmAudioPlayer = null;
        [SerializeField]
        private AudioSource _sfxAudioPlayer = null;
        [SerializeField]
        private AudioClip _confirmSound = null;
        [SerializeField]
        private AudioClip _cancelSound = null;
        [SerializeField]
        private AudioClip _findPartnerSound = null;
        [SerializeField]
        private AudioClip _caughtBySharkSound = null;

        public void SwitchToBattleBGM()
        {
            _bgmAudioPlayer.Stop();
            _bgmAudioPlayer.clip = _caughtBySharkSound;
            _bgmAudioPlayer.volume = 0.4f;
            _bgmAudioPlayer.Play();
        }

        public void PlayConfirm()
        {
            _sfxAudioPlayer.clip = _confirmSound;
            _sfxAudioPlayer.Play();
        }

        public void PlayCancel()
        {
            _sfxAudioPlayer.clip = _cancelSound;
            _sfxAudioPlayer.Play();
        }

        public void PlayFindPartner()
        {
            _sfxAudioPlayer.clip = _findPartnerSound;
            _sfxAudioPlayer.Play();
        }
    }
}
