using UnityEngine;

public class Bowl : MonoBehaviour
{
    [SerializeField] private GameObject food;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PetFood"))
        {
            food.SetActive(true);
        }
    }
}
