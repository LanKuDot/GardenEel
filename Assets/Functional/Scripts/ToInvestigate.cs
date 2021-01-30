using UnityEngine;
using UnityEngine.SceneManagement;

namespace Functional
{
    public class ToInvestigate : MonoBehaviour
    {
        public void ToInvestigateScene()
        {
            SceneManager.LoadScene("Investigate");
        }
    }
}
