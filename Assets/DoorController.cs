using UnityEngine;
using DG.Tweening;//cada que abra un proyecto, debo descargar la libresia DOOTWEEN de internet y añadirlo en Unity

public class DoorController : MonoBehaviour
{
    public Vector3 currentpos;
    public float lastpos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentpos= transform.position; 
        GameEvents.instance.onDoorTriggerEnter += OpenDoor;
        GameEvents.instance.OnDoorTriggerExit += CloseDoor;
    }

    // Update is called once per frame
    void OpenDoor()
    {
        //transform.Translate(new Vector3(00, 2.6f, 0));
        transform.DOMoveY(lastpos, 2);

    }

    void CloseDoor()
    {
        //transform.Translate(new Vector3(00, 3f, 0));
        transform.DOMoveY(currentpos.y, 2);   

    }
}
