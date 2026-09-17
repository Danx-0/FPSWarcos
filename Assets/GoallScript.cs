using UnityEngine;

public class GoallScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.WinGame();
        }
    }
}
