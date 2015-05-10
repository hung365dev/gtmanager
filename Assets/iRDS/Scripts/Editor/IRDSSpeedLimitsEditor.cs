using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[UnityEditor.CustomEditor(typeof(IRDSSpeedLimits))]
public class IRDSSpeedLimitsEditor : Editor {
	
	
	public override void OnInspectorGUI()
	{
		
//		IRDSSpeedLimits speedLimits = (IRDSSpeedLimits) target;
	
		
		GUI.changed = false;
		
		SerializedProperty hillradius = serializedObject.FindProperty("Hj");
		
		GUILayout.BeginHorizontal();
		EditorGUILayout.PropertyField(hillradius,new GUIContent("Hill Radius","This is the value of the radius of the Hill, for make the AI Drivers to slow down!"));
		GUILayout.EndHorizontal();
		
		if (GUI.changed)
			serializedObject.ApplyModifiedProperties();
	}
}
