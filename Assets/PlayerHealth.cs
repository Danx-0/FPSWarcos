using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{


    [SerializeField]
    private float maxHealth = 5;
    private float health;

    [SerializeField]
    private Slider healthSlider;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        healthSlider.value = health/maxHealth;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage (float damage)// pa que cuando muera reinicie el juego 
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        healthSlider.value = health/maxHealth;
        if (health <= 0)
        {
            GameManager.instance.GameOverGame();
        }
    }
}
