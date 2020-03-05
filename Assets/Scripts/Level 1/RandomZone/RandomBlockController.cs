using System;
using UnityEngine;

namespace Level_1.RandomZone
{
    public class RandomBlockController : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;
        private Material _dissolveController;
        private static readonly int DissolveController = Shader.PropertyToID("Vector1_F5F8AAFD");

        private float _dissolveState;

        private void Awake()
        {
            _dissolveController = meshRenderer.material;
            _dissolveState = _dissolveController.GetFloat(DissolveController);
        }

        private void Update()
        {
            if (_dissolveState >= -1f)
            {
                _dissolveState -= Time.deltaTime * 5;
                _dissolveController.SetFloat(DissolveController, _dissolveState);
            }
        }
    }
}