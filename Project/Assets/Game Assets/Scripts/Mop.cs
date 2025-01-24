using System.Collections;
using UnityEngine;

public class Mop : MonoBehaviour
{
    [SerializeField] private bool isWet;
    [SerializeField] private int cleanedDirt;
    [SerializeField] private GameObject bubblesParticles;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isWet = true;
        }
        else if (other.CompareTag("Dirt"))
        {
            if(isWet)
            {
                StartCoroutine(StartClean(other.gameObject));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Dirt"))
        {
            StopAllCoroutines();
            bubblesParticles.SetActive(false);
        }
    }

    private IEnumerator StartClean(GameObject dirt)
    {
        bubblesParticles.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Destroy(dirt);
        cleanedDirt++;
        bubblesParticles.SetActive(false);
    }
}
