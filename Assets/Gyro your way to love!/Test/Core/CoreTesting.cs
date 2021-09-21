using Gyro_your_way_to_love_.Core;
using UnityEngine;

namespace Gyro_your_way_to_love_.Test.Core
{
    public class CoreTesting : MonoBehaviour
    {
        public Transform cube;
        
        private RunnableTest runnableTest;
        
        // Start is called before the first frame update
        private void Start()
        {
            RunnableUtils.Setup(ref runnableTest, gameObject, cube, 1f, Vector3.up);
        }

        // Update is called once per frame
        private void Update()
        {
            RunnableUtils.Run(ref runnableTest, gameObject, Input.GetKey(KeyCode.Space));

            if(Input.GetKeyDown(KeyCode.A))
            {
                runnableTest.Enabled = !runnableTest.Enabled;
            }
        }
    }
}