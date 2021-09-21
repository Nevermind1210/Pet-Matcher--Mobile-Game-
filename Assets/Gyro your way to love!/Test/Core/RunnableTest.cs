using Gyro_your_way_to_love_.Core;
using UnityEngine;

namespace Gyro_your_way_to_love_.Test.Core
{
    public class RunnableTest : RunnableBehaviour
    {
        public Transform cube;
        public float speed;
        public Vector3 direction;
        
        protected override void OnSetup(params object[] _params)
        {
            cube = (Transform) _params[0];
            speed = (float) _params[1];
            direction = (Vector3) _params[2];
        }

        protected override void OnRun(params object[] _params)
        {
            bool canMove = (bool) _params[0];
            if(canMove)
            {
                cube.position += direction * speed * Time.deltaTime;
            }
        }
    }
}