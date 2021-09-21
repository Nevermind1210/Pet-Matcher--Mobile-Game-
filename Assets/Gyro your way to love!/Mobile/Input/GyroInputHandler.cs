using System;
using Gyro_your_way_to_love_.Core;
using UnityEngine;

namespace Gyro_your_way_to_love_.Mobile.Input
{
    public class GyroInputHandler : RunnableBehaviour
    {
        [Serializable]
        public class GyroscopeState
        {
            public Vector3 rotationDelta;
            public Quaternion deviceRotation;
            public Vector3 acceleration;
        }

        public GyroscopeState gyroscopeState = new GyroscopeState();
        
        protected override void OnSetup(params object[] _params)
        {
            // Detect if the gyroscrope is actually supported on this device (most should)
            UnityEngine.Input.gyro.enabled = SystemInfo.supportsGyroscope;
        }

        protected override void OnRun(params object[] _params)
        {
            gyroscopeState.deviceRotation = UnityEngine.Input.gyro.attitude;
            gyroscopeState.rotationDelta = UnityEngine.Input.gyro.rotationRateUnbiased;
            gyroscopeState.acceleration = UnityEngine.Input.acceleration;
        }
    }
}