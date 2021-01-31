using UnityEngine;
using UnityEngine.SceneManagement;

namespace Functional
{
    public class TutorialSceneManager : MonoBehaviour
    {
        public void ToInvestigateScene()
        {
            var obj = FindObjectOfType<AudioSource>();
            Destroy(obj.gameObject);
            SceneManager.LoadScene("Investigate");
        }
    }
}
