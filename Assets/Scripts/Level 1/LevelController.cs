using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Level_1
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private MouseLook cameraController;
        [SerializeField] private TMPro.TextMeshProUGUI timerDisplay;
        [SerializeField] private TMPro.TextMeshProUGUI endTimer;
        [SerializeField] private Canvas levelUi;
        [SerializeField] private Canvas endScreen;

        private float _timer;
        private bool _started = false;

        private void Awake()
        {
            timerDisplay.enabled = false;
            endScreen.enabled = false;
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
            levelFinished();
        }

        private void levelFinished()
        {
            levelUi.enabled = false;
            endScreen.enabled = true;
            endTimer.text = _timer.ToString("f2");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            cameraController.LevelFinished();
        }
    }
}