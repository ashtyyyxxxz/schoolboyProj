using UnityEngine;

public class Faucet : MonoBehaviour
{
    [SerializeField] private GameObject water;
    private bool isWaterTurnedOn = false;

    public void TurnWater()
    {
        isWaterTurnedOn = !isWaterTurnedOn;
        FindAnyObjectByType<Bucket>().readyToFill = isWaterTurnedOn;
        FindAnyObjectByType<Bucket>().StopAllCoroutines();
        water.SetActive(isWaterTurnedOn);

        if(isWaterTurnedOn)
            GetComponent<AudioSource>().Play();
        else
            GetComponent<AudioSource>().Stop();
    }
}
