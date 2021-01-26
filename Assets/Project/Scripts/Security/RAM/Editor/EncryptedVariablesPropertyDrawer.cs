using UnityEngine;
using UnityEditor;
using System.Text;

namespace Project
{
    [CustomPropertyDrawer(typeof(pint))]
    public class PintPropertyDrawer : PropertyDrawer
    {
        #region Methods
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty valueProperty = property.FindPropertyRelative("value");
            SerializedProperty offsetProperty = property.FindPropertyRelative("offset");

            position = EditorGUI.PrefixLabel(position, label);

            int value = valueProperty.intValue - offsetProperty.intValue;
            int newOffset = System.Environment.TickCount + 101;
            int newValue = EditorGUI.IntField(position, value);

            valueProperty.intValue = newValue + newOffset;
            offsetProperty.intValue = newOffset;
        }
        #endregion
    }

    [CustomPropertyDrawer(typeof(pfloat))]
    public class PfloatPropertyDrawer : PropertyDrawer
    {
        #region Methods
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty valueProperty = property.FindPropertyRelative("value");
            SerializedProperty offsetProperty = property.FindPropertyRelative("offset");

            position = EditorGUI.PrefixLabel(position, label);

            float value = valueProperty.floatValue - offsetProperty.intValue;
            int newOffset = System.Environment.TickCount % 100;
            float newValue = EditorGUI.DelayedFloatField(position, value);

            valueProperty.floatValue = newValue + newOffset;
            offsetProperty.intValue = newOffset;
        }
        #endregion
    }

    [CustomPropertyDrawer(typeof(pstring))]
    public class PstringPropertyDrawer : PropertyDrawer
    {
        #region Methods
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty valueBytesProperty = property.FindPropertyRelative("value");
            SerializedProperty keyProperty = property.FindPropertyRelative("key");

            byte[] valueBytes = new byte[valueBytesProperty.arraySize];
            byte key = (byte)keyProperty.intValue;

            for (int i = 0; i < valueBytes.Length; i++)
                valueBytes[i] = (byte)(valueBytesProperty.GetArrayElementAtIndex(i).intValue ^ key);

            position = EditorGUI.PrefixLabel(position, label);

            string value = Encoding.Default.GetString(valueBytes);
            string newValue = EditorGUI.TextField(position, value);

            byte[] newValueBytes = Encoding.Default.GetBytes(newValue);
            byte newKey = (byte)(System.Environment.TickCount % 255);

            for (int i = 0; i < newValueBytes.Length; i++)
                newValueBytes[i] ^= newKey;

            valueBytesProperty.arraySize = newValueBytes.Length;

            for (int i = 0; i < newValueBytes.Length; i++)
                valueBytesProperty.GetArrayElementAtIndex(i).intValue = newValueBytes[i];

            keyProperty.intValue = newKey;
        }
        #endregion
    }
}
