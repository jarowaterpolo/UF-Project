using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public GameObject FinishGameScreen;
    private bool FinishScreenActive;

    private void Update()
    {
        if (FinishScreenActive == true)
        {
            FinishGameScreen.SetActive(true);
        }
        else
        {
            FinishGameScreen.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            FinishScreenActive = true;
        }
    }
}
