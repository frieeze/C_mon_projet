using System;
using UnityEngine;

namespace Menu
{
    public class HiddenTheRock : MonoBehaviour
    {
        [SerializeField] private GameObject image;

        private void Awake()
        {
            image.SetActive(false);
        }

        public void handleDisplay()
        {
            image.SetActive(true);
        }
    }
}