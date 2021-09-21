using System;
using Gyro_your_way_to_love_.Mobile.Input;

using UnityEngine;

namespace Gyro_your_way_to_love_.Mobile.Input
{
    public class Steering : MonoBehaviour
    {
        [SerializeField] private float speed = 1;

        private void Update()
        {
            Vector3 rotation = MobileInputManager.GetGyroscopeState().acceleration;
            transform.localEulerAngles = new Vector3(0, rotation.x * 45f, 0);

            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
