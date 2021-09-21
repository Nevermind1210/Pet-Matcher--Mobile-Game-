using Gyro_your_way_to_love_.Mobile.Input;
using UnityEngine;

namespace Gyro_your_way_to_love_.Test.Mobile
{
    public class GyroTest : MonoBehaviour
    {
        private Quaternion initialRotation;
        private new Rigidbody rigidbody;
        
        // Start is called before the first frame update
        void Start()
        {
            initialRotation = MobileInputManager.GetGyroscopeState().deviceRotation;
            rigidbody = gameObject.GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            // Quaternion currentRotation = MobileInputManager.GetGyroscopeState().deviceRotation;
            //
            // // THis is how you 'subtract' quaternions
            // Quaternion difference = initialRotation * Quaternion.Inverse(currentRotation);
            //
            // difference.ToAngleAxis(out float angle, out Vector3 axis);
            // rigidbody.AddForce(axis * .25f, ForceMode.Impulse);
            
            Vector3 speed = MobileInputManager.GetGyroscopeState().rotationDelta;
            rigidbody.AddForce(new Vector3(speed.y, 0, -speed.x));
        }
    }
}