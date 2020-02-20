using System;
using UnityEngine;

namespace MainMenu
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