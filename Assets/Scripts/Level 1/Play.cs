using UnityEngine;

namespace Level_1
{
    public class Play : MonoBehaviour
    {
        [SerializeField] private LevelController levelController;

        private void OnTriggerEnter(Collider other)
        {
            levelController.StartTimer();
        }
    }
}