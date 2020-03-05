using UnityEngine;

namespace Level_1
{
    public class Finish : MonoBehaviour
    {
        [SerializeField] private LevelController levelController;

        private void OnTriggerEnter(Collider other)
        {
            levelController.StopTimer();
        }
    }
}