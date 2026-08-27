using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    public event Action onDoorTriggerEnter;
   public event Action OnDoorTriggerExit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }

    public void OpenTriggerDoor()
    {
        onDoorTriggerEnter();
    }
    public void CloseTriggerDoor()
    {
        OnDoorTriggerExit();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
