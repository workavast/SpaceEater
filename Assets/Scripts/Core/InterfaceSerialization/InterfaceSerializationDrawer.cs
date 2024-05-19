using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SourceCode.Core.InterfaceSerialization
{
    [CustomPropertyDrawer(typeof(InterfaceSerializationAttribute))]
    public class InterfaceSerializationDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var atr = attribute as InterfaceSerializationAttribute;

            if (atr == null ||  !ValidateFieldType())
            {
                DrawError(position);
                return;
            }
            
            var reqType = atr.Type;
            CheckCursorPosition(position, reqType);
            CheckExistValues(property, reqType);
            DrawField(position, property, label, reqType);
        }

        private bool ValidateFieldType() 
            => fieldInfo.FieldType == typeof(Object) ||
               typeof(IEnumerable<Object>).IsAssignableFrom(fieldInfo.FieldType);

        private void CheckExistValues(SerializedProperty property, Type reqType)
        {
            if (property.objectReferenceValue != null && !IsValid(property.objectReferenceValue, reqType))
                property.objectReferenceValue = null;
        }

        private void DrawField(Rect position, SerializedProperty property, GUIContent label, Type reqType)
            => property.objectReferenceValue = EditorGUI.ObjectField(position, label, property.objectReferenceValue, reqType, true);

        private void CheckCursorPosition(Rect position, Type reqType)
        {
            if (position.Contains(Event.current.mousePosition))
            {
                var dragAndDropObjects = DragAndDrop.objectReferences.Length;

                for (int i = 0; i < dragAndDropObjects; i++)
                {
                    if (!IsValid(DragAndDrop.objectReferences[i], reqType))
                    {
                        DragAndDrop.visualMode = DragAndDropVisualMode.Rejected;
                        break;
                    }
                }
            }
        }

        private bool IsValid(Object objectReference, Type reqType)
            => reqType.IsInstanceOfType(objectReference);

        private void DrawError(Rect position)
            => EditorGUI.HelpBox(position, "Error", MessageType.Error);
    }
}