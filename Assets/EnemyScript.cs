using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;


public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private float health = 10;

    private NavMeshAgent agent;

    private Transform Player;

    [SerializeField]
    public GameObject knife;
    [SerializeField]
    public GameObject drop;

    [SerializeField]
    public List<Transform> patrolPoint = new List<Transform>();

    private int currentpoint = 0;
    [SerializeField]
    private Material damageMaterial;

    private Material OrgMaterial;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();   

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // agent.destination = new Vector3(10, 1, 10); 

        Player = GameObject.Find("Player").transform;
        agent.stoppingDistance = 1;
        OrgMaterial = GetComponent<MeshRenderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        //agent.destination = Player.position;
        if (Vector3.Distance(transform.position, Player.position) <= 10)
        {
            agent.destination = Player.position;
        }
        else
        {
            if (Vector3.Distance(transform.position, patrolPoint[currentpoint].position) < 2.5f)
            {
                print("fuciono" + currentpoint);

                currentpoint = (currentpoint + 1) % patrolPoint.Count;

            }
            //agent.destination = transform.position;
            agent.destination = patrolPoint[currentpoint].position;
        }




        if (Vector3.Distance(transform.position, Player.position) <= agent.stoppingDistance)
        {
            knife.SetActive(true);
        }
        else
        {
            knife.SetActive(false);
        }
    }

    void ResetMaterial()
    {
        GetComponent<MeshRenderer>().material = OrgMaterial;
    }

    public void TakeDamage (float value)
    {
        health -= value;
        GetComponent<MeshRenderer>().material = damageMaterial;
        Invoke("ResetMaterial", 0.1f);

        if (health <= 0)
        {
            Instantiate(drop,transform.position, Quaternion.identity);
            GameManager.instance.AddScore(10);
            Destroy (this.gameObject);
        }
    }
}
