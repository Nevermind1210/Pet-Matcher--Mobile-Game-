using TMPro;
using UnityEngine;

namespace Gyro_your_way_to_love_.Xavier_Scripts
{
    public class InputTextShower : MonoBehaviour
    {
        public string theName;
        public GameObject inputField;
        public GameObject textDisplay;
        
        public void StoreName()
        {
            theName = inputField.GetComponent<TextMeshProUGUI>().text;
            textDisplay.GetComponent<TextMeshProUGUI>().text = theName;
        }
        
    }
}