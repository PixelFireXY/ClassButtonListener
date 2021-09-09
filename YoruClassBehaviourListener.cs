using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class YoruClassBehaviourListener : ButtonListener
{
    [ListToPopup(typeof(YoruClassBehaviourListener), "methodsList")]
    [SerializeField] private string currentElementSelected;

    [HideInInspector]
    public List<string> methodsList = new List<string>();

    /******************** Mono ********************/

    private void Awake()
    {
        UpdateDropdownList();
    }
    private void OnValidate()
    {
        UpdateDropdownList();
    }

    /******************** Inspector button ********************/

    private void UpdateDropdownList()
    {
        methodsList.Clear();

        MethodInfo[] methodInfos = typeof(YourClassBehaviour).GetMethods();

        foreach (var method in methodInfos)
        {
            if (method.DeclaringType == typeof(YourClassBehaviour) &&
                method.IsPublic &&
                method.ToString().Contains("System.Action") == false)
            {
                methodsList.Add(method.Name);
            }
        }
    }

    /******************** Button listener ********************/

    protected override void OnClickButton()
    {
        YourClassBehaviour.Instance.Invoke(currentElementSelected, 0f);
    }
}
