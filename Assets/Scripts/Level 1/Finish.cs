using UnityEngine;

namespace Level_1
{
    public class Finish : MonoBehaviour
    {
        [SerializeField] private Timer timerController;

        private void OnTriggerEnter(Collider other)
        {
            timerController.StopTimer();
        }
    }
}