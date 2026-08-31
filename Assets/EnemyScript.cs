using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private float health = 10;

    private NavMeshAgent agent;

    private Transform Player;

    [SerializeField]
    public GameObject knife;

    [SerializeField]
    public List<Transform> patrolPoint = new List<Transform>();

    private int currentPoint;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();   

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // agent.destination = new Vector3(10, 1, 10); 

        Player = GameObject.Find("Player").transform;
        agent.stoppingDistance = 2;
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
                if (Vector3.Distance(transform.position, patrolPoint[currentPoint].position) >=3 )
                {
                    agent.destination = patrolPoint[currentPoint].position;
                }
            else
            {
                if (currentPoint < patrolPoint.Count-1)
                {
                  currentPoint++;
                }
                else
                {
                    currentPoint = 0;
                }
                
            }

                //agent.destination = transform.position;
                //agent.destination = patrolPoint[0].position;
        }




        if (Vector2.Distance(transform.position, Player.position) <= agent.stoppingDistance)
        {
            knife.SetActive(true);
        }
        else
        {
            knife.SetActive(false);
        }
    }

    public void TakeDamage (float value)
    {
        health -= value;    
       // GetComponent
        if (health <= 0)
        {
            Destroy (this.gameObject);
        }
    }
}
