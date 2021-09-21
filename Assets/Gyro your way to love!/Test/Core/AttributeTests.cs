using Gyro_your_way_to_love_.Core;
using UnityEngine;

namespace Gyro_your_way_to_love_.Test.Core
{
    public class AttributeTests : MonoBehaviour
    {
        [Tag, SerializeField] private string playerTag;
        [Tag, SerializeField] private string finishTag = "Finish";

        [SerializeField, ReadOnly] private string thing = "12346";

        [SerializeField, SceneField] private string testLevel;
    }
}