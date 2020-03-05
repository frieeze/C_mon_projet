using System;
using UnityEngine;

namespace Level_1
{
    public class Play : MonoBehaviour
    {
        [SerializeField] private Timer timerController;

        private void OnTriggerEnter(Collider other)
        {
            timerController.StartTimer();
        }
    }
}