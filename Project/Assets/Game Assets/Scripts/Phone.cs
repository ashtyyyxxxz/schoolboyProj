using DialogueEditor;
using UnityEngine;

public class Phone : MonoBehaviour
{
    private bool isInteractedBefore=false;
    [SerializeField] private AudioClip phoneDrop;
    public void OnLeft()
    {
        if (isInteractedBefore==false)
        {
            GetComponent<Interactor>().onInteracted.RemoveAllListeners();
            GetComponent<Interactor>().onEnteredZone.RemoveAllListeners();
            GetComponent<AudioSource>().clip = phoneDrop;
            GetComponent<AudioSource>().Play();
            isInteractedBefore = false;
        }

    }
}
