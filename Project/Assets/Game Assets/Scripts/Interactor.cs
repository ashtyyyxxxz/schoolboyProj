using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private InteractButton interactButton;
    [SerializeField] private Transform uiButtonSpawnParent;
    public UnityEvent onEnteredZone, onInteracted, onLeftZone;

    private enum InteractButton { AButton,BButton }

    private GameObject spawnedButton;

    private InputActionReference aInput, bInput;

    private void OnEnable()
    {
        
    }

    private void BButtonPressed(InputAction.CallbackContext obj)
    {
        onInteracted?.Invoke();
    }

    private void AButtonPressed(InputAction.CallbackContext obj)
    {
        onInteracted?.Invoke();
        Test("venom");
    }

    private void OnDisable()
    {
        
    }

    public void Test(string textt)
    {
        Debug.Log(textt);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            onEnteredZone?.Invoke();
            switch (interactButton)
            {
                case InteractButton.AButton:
                    spawnedButton = Instantiate(UIUXManager.instance.buttonA, uiButtonSpawnParent != null ? uiButtonSpawnParent : transform);
                    aInput = UIUXManager.instance.aInput;
                    aInput.action.performed += AButtonPressed;
                    Debug.Log(aInput);
                    break;

                case InteractButton.BButton:
                    spawnedButton = Instantiate(UIUXManager.instance.buttonB, uiButtonSpawnParent != null ? uiButtonSpawnParent : transform);
                    bInput = UIUXManager.instance.bInput;
                    bInput.action.performed += BButtonPressed;
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(spawnedButton!=null)
            Destroy(spawnedButton);

        onLeftZone?.Invoke();

        switch(interactButton)
        {
            case InteractButton.AButton:
                aInput = null;
                break;

            case InteractButton.BButton:
                bInput = null;
                break;
        }
    }
}
