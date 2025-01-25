using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    [SerializeField] private Transform water;
    [SerializeField] private ParticleSystem waterParticles;
    public bool readyToFill = true;

    private bool isUnfilling = false;
    private float amountOfWater;

    private void Update()
    {
        if (amountOfWater == 0)
            water.gameObject.SetActive(false);

        if (transform.localRotation.x > 0.64f || transform.localRotation.x < -0.64f || transform.localRotation.z > 0.64f || transform.localRotation.z < -0.64f)
        {
            if (!isUnfilling && amountOfWater > 0)
            {
                StartCoroutine(UnFillWater());
                waterParticles.gameObject.SetActive(true);
            }
        }
        else
        {
            StopCoroutine(UnFillWater());
            isUnfilling = false;
            waterParticles.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            StartCoroutine(FillWater());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            StopAllCoroutines();
            readyToFill = true;
        }
    }

    private IEnumerator UnFillWater()
    {
        isUnfilling = true;
        while (amountOfWater > 0 && isUnfilling)
        {
            amountOfWater -= 0.00625f;
            water.localPosition = new Vector3(0, Mathf.Lerp(-0.1616f, 0.153f, amountOfWater), 0);
            float scale = Mathf.Lerp(0.3f, 0.35f, amountOfWater);
            water.localScale = new Vector3(scale, 0, scale);
            yield return new WaitForSeconds(0.05f);
        }
        isUnfilling = false;
        waterParticles.gameObject.SetActive(false);
    }

    private IEnumerator FillWater()
    {
        if (readyToFill)
        {
            water.gameObject.SetActive(true);
            readyToFill = false;
            while(amountOfWater < 1)
            {
                amountOfWater += 0.00625f;
                water.localPosition = new Vector3(0, Mathf.Lerp(-0.1616f, 0.153f, amountOfWater),0);
                float scale = Mathf.Lerp(0.3f, 0.35f, amountOfWater);
                water.localScale = new Vector3(scale, 0, scale);
                yield return new WaitForSeconds(0.05f);
            }
            readyToFill = true;
        }

    }
}
