using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{

    [Range(0, 9999)]public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public Text healthNumber;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SliderMaxHealth(maxHealth);
    }

    void Update()
    {

    }
    void TakeDamdge(int damadge)
    {
        currentHealth -= damadge;

        healthBar.SliderCurrentHealth(currentHealth);
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if(gameObject.tag == "Enemy" && collision.collider.tag == "Arrow") TakeDamdge(Random.Range(5, 55));
        else if(gameObject.tag == "Player" && collision.collider.tag == "EnemyArrow") TakeDamdge(Random.Range(5, 55));
    }
}
