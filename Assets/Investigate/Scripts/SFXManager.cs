using UnityEngine;

namespace Investigate
{
    public class SFXManager : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _audioPlayer = null;
        [SerializeField]
        private AudioClip _confirmSound = null;
        [SerializeField]
        private AudioClip _cancelSound = null;
        [SerializeField]
        private AudioClip _findPartnerSound = null;

        public void PlayConfirm()
        {
            _audioPlayer.clip = _confirmSound;
            _audioPlayer.Play();
        }

        public void PlayCancel()
        {
            _audioPlayer.clip = _cancelSound;
            _audioPlayer.Play();
        }

        public void PlayFindPartner()
        {
            _audioPlayer.clip = _findPartnerSound;
            _audioPlayer.Play();
        }
    }
}
