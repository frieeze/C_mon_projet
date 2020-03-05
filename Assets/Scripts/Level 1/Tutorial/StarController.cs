using System.Collections;
using Tutorial;
using UnityEngine;

namespace Level_1.Tutorial
{
    public class StarController : MonoBehaviour
    {
        [SerializeField] private TutoLinesController tutoController;
        private GameObject _keyGo;
        private Transform _keyTransform;
        private float _rotationAngle;

        private float _rotationSpeed = -1;


        private void Awake()
        {
            _keyGo = gameObject;
            _keyTransform = transform;
        }

        private void Update()
        {
            _rotationAngle = (_rotationAngle + _rotationSpeed) % 360;
            _keyTransform.rotation = Quaternion.Euler(0f, _rotationAngle, 0f);
        }

        private IEnumerator TutoEnding()
        {
            tutoController.OnTutoEnding(true);
            yield return new WaitForSeconds(5f);
            tutoController.OnCrouchZone(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                StartCoroutine(TutoEnding());
        }
    }
}