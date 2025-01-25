using TMPro;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    public bool isShelfFull;

    public int requiredAmount;
    public int currentAmount;

    [SerializeField] private TextMeshProUGUI questStatusText;

    private void Update()
    {
        if (isShelfFull)
            questStatusText.text = "Статус: выполнено";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cloth"))
        {
            currentAmount++;
            if (currentAmount == requiredAmount) isShelfFull = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cloth"))
        {
            currentAmount--;
            isShelfFull = false;
        }
    }
}
