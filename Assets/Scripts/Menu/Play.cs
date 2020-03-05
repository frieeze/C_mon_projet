using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class Play : MonoBehaviour
    {
        public void OnPlayClick()
        {
            SceneManager.LoadScene(1);
        }
    }
}
