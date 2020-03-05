using UnityEngine;

namespace Menu
{
    public class ButtonStyleController : MonoBehaviour
    {
        public void colorToPurple(TMPro.TextMeshProUGUI text)
        {
            text.color = new Color(201, 0, 255);
        }

        public void colorToWhite(TMPro.TextMeshProUGUI text)
        {
            text.color = Color.white;
        }
    }
}