using System;
using UnityEngine;

namespace Tutorial
{
    public class TutoLinesController : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private TMPro.TextMeshProUGUI tutorialText;

        [SerializeField] private TutorialLine crouch;
        [SerializeField] private TutorialLine longJump;
        [SerializeField] private TutorialLine wallJump;
        [SerializeField] private TutorialLine tutoEnding;

        private void Awake()
        {
            panel.SetActive(false);
        }

        private bool _inTutorialZone = false;

        public void OnCrouchZone(bool isIn)
        {
            if (isIn)
            {
                panel.SetActive(true);
                tutorialText.text = crouch.text;
            }
            else
            {
                panel.SetActive(false);
            }
        }
        public void OnLonJumpZone(bool isIn)
        {
            if (isIn)
            {
                panel.SetActive(true);
                tutorialText.text = longJump.text;
            }
            else
            {
                panel.SetActive(false);
            }
        }
        public void OnWallJumpZone(bool isIn)
        {
            if (isIn)
            {
                panel.SetActive(true);
                tutorialText.text = wallJump.text;
            }
            else
            {
                panel.SetActive(false);
            }
        }
        public void OnTutoEnding(bool isIn)
        {
            if (isIn)
            {
                panel.SetActive(true);
                tutorialText.text = tutoEnding.text;
            }
            else
            {
                panel.SetActive(false);
            }
        }
    }
}
