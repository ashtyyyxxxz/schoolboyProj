using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCan : MonoBehaviour
{
    [SerializeField] private GameObject particles;
    [SerializeField] private BoxCollider triggerZone;
    private bool isFilled = false;

    private void Update()
    {
        if (transform.localRotation.x > 0.5f || transform.localRotation.x < -0.5f || transform.localRotation.z > 0.5f || transform.localRotation.z < -0.5f)
        {
            particles.SetActive(true);
            triggerZone.enabled = true;
        }
        else
        {
            particles.SetActive(false);
            triggerZone.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            isFilled = true;
        }
        if (other.CompareTag("Flower"))
        {
            StartCoroutine(WateringFlowers(other.transform));
        }
    }

    private IEnumerator WateringFlowers(Transform flower)
    {
        yield return new WaitForSeconds(2.5f);
        flower.GetComponent<Flower>().checkmark.SetActive(true);
    }
}
