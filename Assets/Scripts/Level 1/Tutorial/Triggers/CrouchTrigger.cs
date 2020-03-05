using UnityEngine;

namespace Tutorial.Triggers
{
    public class CrouchTrigger : MonoBehaviour
    {
        [SerializeField] private TutoLinesController tutoController;

        private void OnTriggerEnter(Collider other)
        {
            tutoController.OnCrouchZone(true);
        }

        private void OnTriggerExit(Collider other)
        {
            tutoController.OnCrouchZone(false);
        }
    }
}
