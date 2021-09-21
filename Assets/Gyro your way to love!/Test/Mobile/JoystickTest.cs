using Gyro_your_way_to_love_.Mobile.Input;
using UnityEngine;

namespace Gyro_your_way_to_love_.Test.Mobile
{
    public class JoystickTest : MonoBehaviour
    {
        // Update is called once per frame
        private void Update()
        {
            Vector2 joystickAxis = MobileInputManager.GetJoystickAxis();
            
            transform.position += transform.right * (joystickAxis.x * Time.deltaTime);
            transform.position += transform.forward * (joystickAxis.y * Time.deltaTime);
        }
    }
}