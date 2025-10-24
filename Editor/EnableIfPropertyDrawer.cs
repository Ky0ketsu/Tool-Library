using UnityEditor;
using UnityEngine;
using System.Reflection;

namespace Ky0ketsu.EditorOnly
{
    [CustomPropertyDrawer(typeof(EnableIfAttribute))]
    public class EnableIfPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {   
            EnableIfAttribute enableIfAttribute = attribute as EnableIfAttribute;
            //SerializedObject propertyContainer = property.serializedObject;
            SerializedProperty ActivatorProperty = property.serializedObject.FindProperty(enableIfAttribute.fieldName);
            bool isEnabled = ActivatorProperty.boolValue;

            if (ActivatorProperty == null)
            {
                isEnabled = ActivatorProperty.boolValue;
            }
            else
            {
                bool didFoundValue = false;
                foreach (FieldInfo fieldInfo in property.serializedObject.targetObject.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    if(fieldInfo.Name == enableIfAttribute.fieldName)
                    {
                        isEnabled = (bool)fieldInfo.GetValue(property.serializedObject.targetObject);
                        didFoundValue = true;
                        break;
                    }
                }
                if (didFoundValue)
                {
                    foreach (PropertyInfo propertyInfo in property.serializedObject.targetObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                    {
                        if (propertyInfo.Name == enableIfAttribute.fieldName)
                        {
                            isEnabled = (bool)propertyInfo.GetValue(property.serializedObject.targetObject);
                            didFoundValue = true;
                            break;
                        }
                    }
                }

                if (!didFoundValue)
                {
                    Debug.Log("MissingValue" + enableIfAttribute.fieldName);
                }
            }


            GUI.enabled = isEnabled;
            if(isEnabled)
            {
                GUI.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            }
            else
            {
                GUI.color = Color.white;
            }


                EditorGUI.PropertyField(position, property, label);
            GUI.enabled = true;
        }
    }
}
