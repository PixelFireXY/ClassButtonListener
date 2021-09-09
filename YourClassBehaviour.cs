using UnityEngine;

public class YourClassBehaviour : MonoBehaviour
{
	public static YourClassBehaviour Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    public void MethodShowedOnDropdown() { }
    public void AnotherMethodShowedOnDropdown() { }
    private void MethodNotShowedOnDropdown() { }
}
