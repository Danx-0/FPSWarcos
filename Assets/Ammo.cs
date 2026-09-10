using UnityEngine;
using UnityEngine.Rendering;
//System;
//System.Collections.Generic;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    private int amountAmmo = 5;
    private int amountTime = 2;
    private int amountLife = 25;


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public enum pickupSelection
    {
       Life,
       ammo,
       time,

    }
    public pickupSelection currentSelection;

   

    void Start()
    {
        int value = UnityEngine.Random.Range(0, 10);
        if (value>7.5)
        {
            currentSelection = pickupSelection.time;
            GetComponent<MeshRenderer>().material.color = Color.yellow;

        }
        else if (value > 5)
        {
            currentSelection = pickupSelection.Life;
            GetComponent<MeshRenderer>().material.color = Color.pink;
        }
        else
        {
            currentSelection= pickupSelection.ammo;
            GetComponent<MeshRenderer>().material.color  = Color.aquamarine;        
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * 45, 0);//para que tenga una animacion el objeto que en este caso es girar 
    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (currentSelection)
            {
                case pickupSelection.Life:
                    other.GetComponent<PlayerHealth>().TakeDamage(-amountLife);
                    break;
                case pickupSelection.ammo:
                    other.transform.GetChild(1).GetComponent<PlayerShoot>().AddBullets(amountAmmo);
                    break;
                case pickupSelection.time:
                    GameManager.instance.AddTime(amountTime);
                    break;

            }
            
            
        }
        Destroy(this.gameObject);
    }
}
