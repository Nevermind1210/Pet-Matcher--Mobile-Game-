using System;
using TMPro;
using UnityEngine;

namespace Gyro_your_way_to_love_.Xavier_Scripts
{
    public class InputTextShower : MonoBehaviour
    {
        [SerializeField] private string theName;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private GameObject textDisplay;
        [SerializeField] private TMP_InputField passwordBox;

        // private void Update()
        // {
        //     if (inputField)
        //     {
        //         TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, true);
        //     }
        //     inputField.keyboardType = TouchScreenKeyboardType.Default;
        // }

        public void StoreName()
        {
            theName = inputField.GetComponent<TextMeshProUGUI>().text;
            textDisplay.GetComponent<TextMeshProUGUI>().text = theName;
        }

        public void PasswordMask()
        {
            if (passwordBox)
            {
                TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, true);
            }
            passwordBox.keyboardType = TouchScreenKeyboardType.Default;
            passwordBox.inputType = TMP_InputField.InputType.Password;
        }
    }
}