using UnityEngine;
using UnityEngine.SceneManagement;

namespace Functional
{
    public class TutorialSceneManager : MonoBehaviour
    {
        public void ToInvestigateScene()
        {
            SceneManager.LoadScene("Investigate");
        }
    }
}
