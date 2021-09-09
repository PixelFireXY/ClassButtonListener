using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class ButtonListener : MonoBehaviour
{    
    protected void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => OnClickButton());      
    }

    protected abstract void OnClickButton();    
}
