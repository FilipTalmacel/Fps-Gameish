using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    [Range(0, 9999)] public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public Text healthNumber;

    //public float damadgeModifier;

    public MeleeAttack meleeAttack;
    public EnemyManager enemyManager;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SliderMaxHealth(maxHealth);
    }

    void Update()
    {
        if (healthBar.healthSlider.value <= 0 && !enemyManager.dead)
        {
            enemyManager.Dead();
        }
    }
    void TakeDamdge(int damadge)
    {
        currentHealth -= damadge;

        healthBar.SliderCurrentHealth(currentHealth);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Arrow") TakeDamdge(Random.Range(5, 55));

        if (collision.collider.tag == "Sword") TakeDamdge(meleeAttack.DamadgeModifier);
        //Debug.Log(collision.collider.tag);
    }
}
