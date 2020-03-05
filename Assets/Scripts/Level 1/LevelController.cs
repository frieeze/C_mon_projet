using Player;
using UnityEngine;

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
        private bool _started;

        private void Awake()
        {
            timerDisplay.enabled = false;
            endScreen.enabled = false;
            Cursor.visible = false;
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

        public void resetTimer()
        {
            _started = false;
            _timer = 0f;
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