using UnityEngine;
using UnityEngine.SceneManagement;

namespace Functional
{
    public class ResultSceneManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _winUI = null;
        [SerializeField]
        private GameObject _loseUI = null;
        [SerializeField]
        private bool _result;

        private void Start()
        {
            if (_result)
                _winUI.SetActive(true);
            else
                _loseUI.SetActive(true);
        }

        public void BackToInvestigate()
        {
            SceneManager.LoadScene("Investigate");
        }

        public void QuitTheGame()
        {
            Application.Quit();
        }
    }
}
