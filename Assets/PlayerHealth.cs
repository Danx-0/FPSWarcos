using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float health = 10;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage (float damage)// pa que cuando muera reinicie el juego 
    {
        health -= damage;   
        if (health <= 0)
        {
            GameManager.instance.ReloadLevel();
        }
    }
}
