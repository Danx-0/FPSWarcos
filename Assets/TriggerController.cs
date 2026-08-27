using UnityEngine;

public class TriggerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.instance.OpenTriggerDoor();
        //
    }

    private void OnTriggerExit(Collider other)
    {
        GameEvents.instance.CloseTriggerDoor();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
