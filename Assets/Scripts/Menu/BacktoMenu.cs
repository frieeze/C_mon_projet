using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class BacktoMenu : MonoBehaviour
    {
        public void OnBackToMainMenuClick()
        {
            SceneManager.LoadScene(0);
        }
    }
}