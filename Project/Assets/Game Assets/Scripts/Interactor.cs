using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    [SerializeField] private InteractButton interactButton;

    public UnityEvent onEnteredZone, onInteracted, onLeftZone;

    private enum InteractButton { AButton,BButton }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
