using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ListToPopupAttribute : PropertyAttribute
{
    public Type myType;
    public string propertyName;

    public ListToPopupAttribute(Type _myType, string _propertyName)
    {
        myType = _myType;
        propertyName = _propertyName;
    }
}

[CustomPropertyDrawer(typeof(ListToPopupAttribute))]
public class ListToPopupDrawer : PropertyDrawer
{
#if UNITY_EDITOR
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        ListToPopupAttribute popupAttribute = attribute as ListToPopupAttribute;
        List<string> propertiesList = null;

        if (popupAttribute.myType.GetField(popupAttribute.propertyName) != null)
        {
            propertiesList = popupAttribute.myType.GetField(popupAttribute.propertyName).GetValue(popupAttribute.myType) as List<string>;
        }

        if (propertiesList != null && propertiesList.Count > 0)
        {
            int selectedIndex = Mathf.Max(propertiesList.IndexOf(property.stringValue), 0);
            selectedIndex = EditorGUI.Popup(position, property.name, selectedIndex, propertiesList.ToArray());
            property.stringValue = propertiesList[selectedIndex];
        }
        else
        {
            EditorGUI.LabelField(position, label);
        }
    }
#endif
}
