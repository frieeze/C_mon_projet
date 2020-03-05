using System;
using System.Collections;
using UnityEngine;

namespace Level_1
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI timerDisplay;

        private float _timer;
        private bool _started = false;

        private void Awake()
        {
            timerDisplay.enabled = false;
        }

        private void Update()
        {
            if (_started)
            {
                _timer += Time.deltaTime;
            }

            timerDisplay.text = _timer.ToString("f2");
        }

        public void StartTimer()
        {
            _started = true;
            timerDisplay.enabled = true;
        }

        public void StopTimer()
        {
            _started = false;
        }
    }
}