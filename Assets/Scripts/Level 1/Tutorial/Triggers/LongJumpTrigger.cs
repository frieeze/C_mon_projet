using UnityEngine;

namespace Tutorial.Triggers
{
    public class LongJumpTrigger : MonoBehaviour
    {
        [SerializeField] private TutoLinesController tutoController;

        private void OnTriggerEnter(Collider other)
        {
            tutoController.OnLonJumpZone(true);
        }

        private void OnTriggerExit(Collider other)
        {
            tutoController.OnLonJumpZone(false);
        }
    }
}