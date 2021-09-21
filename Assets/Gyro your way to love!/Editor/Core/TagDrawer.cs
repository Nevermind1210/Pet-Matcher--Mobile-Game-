using Gyro_your_way_to_love_.Core;
using UnityEditor;
using UnityEngine;

namespace Gyro_your_way_to_love_.Editor.Core
{
	[CustomPropertyDrawer(typeof(TagAttribute))]
	public class TagDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
		{
			// Start drawing this specific instance of the tag property
			EditorGUI.BeginProperty(_position, _label, _property);
			// Indicates the block of code is part of the property
			{
				//Determine if the property was set to nothing by default
				bool isNotSet = string.IsNullOrEmpty(_property.stringValue);
				
				// Draw the string as a tag instead of a normal string box
				_property.stringValue = EditorGUI.TagField(_position, _label, 
					isNotSet ? (_property.serializedObject.targetObject as Component)?.gameObject.tag : _property.stringValue);
			}
			// Stop drawing this specific instance of the tag property
			EditorGUI.EndProperty();
		}

		public override float GetPropertyHeight(SerializedProperty _property, GUIContent _label) => EditorGUIUtility.singleLineHeight;
	}
}