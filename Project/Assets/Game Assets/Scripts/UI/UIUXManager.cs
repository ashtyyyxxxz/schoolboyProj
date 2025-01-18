using UnityEngine;
using UnityEngine.InputSystem;

public class UIUXManager : MonoBehaviour
{
    static public UIUXManager instance;

    public GameObject buttonA, buttonB;

    public InputActionReference aInput, bInput;

    private void OnEnable()
    {
        instance = this;
    }
}
