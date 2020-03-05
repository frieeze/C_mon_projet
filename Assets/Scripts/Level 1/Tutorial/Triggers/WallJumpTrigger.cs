using UnityEngine;

namespace Tutorial.Triggers
{
    public class WallJumpTrigger : MonoBehaviour
    {
        [SerializeField] private TutoLinesController tutoController;

        private void OnTriggerEnter(Collider other)
        {
            tutoController.OnWallJumpZone(true);
        }

        private void OnTriggerExit(Collider other)
        {
            tutoController.OnWallJumpZone(false);
        }
    }
}