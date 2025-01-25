using TMPro;
using UnityEngine;

public class Bowl : MonoBehaviour
{
    [SerializeField] private GameObject food;
    [SerializeField] private TextMeshProUGUI questStatusText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PetFood"))
        {
            food.SetActive(true);
            questStatusText.text = "Статус: выполнено";
        }
    }
}
