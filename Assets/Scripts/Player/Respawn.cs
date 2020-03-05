using Level_1;
using UnityEngine;

namespace Player
{
    public class Respawn : MonoBehaviour
    {
        [SerializeField]
        private CharacterController playerController;

        [SerializeField] private LevelController levelController;

        private Vector3 _initialPosition;
        private Transform _playerTransform;

        private void Awake()
        {
            _playerTransform = transform;
            _initialPosition = _playerTransform.position;
        }

        public void respawn()
        {
            playerController.enabled = false;
            _playerTransform.position = _initialPosition;
            playerController.enabled = true;
            levelController.resetTimer();
        }
    }
}