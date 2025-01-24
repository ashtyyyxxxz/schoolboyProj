using UnityEngine;

public class PetFood : MonoBehaviour
{
    [SerializeField] private GameObject foodParticles;

    private void Update()
    {
        if (transform.localRotation.x > 0.64f || transform.localRotation.x < -0.64f || transform.localRotation.z > 0.64f || transform.localRotation.z < -0.64f)
        {
            foodParticles.SetActive(true);
        }
        else
        {
            foodParticles.SetActive(false);
        }
    }
}
