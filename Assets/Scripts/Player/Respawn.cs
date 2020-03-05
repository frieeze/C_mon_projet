using System;
using UnityEngine;

namespace Player
{
    public class Respawn : MonoBehaviour
    {
        private Vector3 _initialPosition;
        private Transform _playerTransform;

        private void Awake()
        {
            _playerTransform = transform;
            _initialPosition = _playerTransform.position;
        }

        public void respawn()
        {
            _playerTransform.position = _initialPosition;
        }
    }
}