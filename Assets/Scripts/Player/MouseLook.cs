using UnityEngine;

namespace Player
{
    public class MouseLook : MonoBehaviour
    {
        public float mouseSensitivity = 30;

        public Transform playerBody;
        private bool _isInMenu;

        private float _xRotation;

        private InputMaster _mouse;
        private Vector2 _mouseDelta;

        // Start is called before the first frame update
        void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _mouse = new InputMaster();
            _mouse.Player.CameraRotation.performed += ctx => _mouseDelta = ctx.ReadValue<Vector2>();
        }


        // Update is called once per frame
        void Update()
        {
            if (!_isInMenu)
            {
                float mousex = _mouseDelta.x * mouseSensitivity * Time.deltaTime;
                float mousey = _mouseDelta.y * mouseSensitivity * Time.deltaTime;

                _xRotation -= mousey;
                _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

                transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

                playerBody.Rotate(Vector3.up * mousex);
            }
        }

        public void LevelFinished()
        {
            _isInMenu = true;
        }

        private void OnEnable()
        {
            _mouse.Enable();
        }

        private void OnDisable()
        {
            _mouse.Disable();
        }
    }
}