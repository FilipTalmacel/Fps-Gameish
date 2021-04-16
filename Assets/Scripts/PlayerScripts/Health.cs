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

    public MeleeAttack meleeAttack;
    public EnemyPunching enemyPunching;
    //Component whoKnows;

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
        //whoKnows = collision.collider.GetComponent<EnemyPunching>();
        if(collision.collider.tag == "EnemyArrow") TakeDamdge(Random.Range(5, 55));

        if (collision.collider.tag == "enemyMelee") TakeDamdge(enemyPunching.damadegModifier);
        //if (collision.collider.tag == "Sword") TakeDamdge(meleeAttack.DamadgeModifier);
        //Debug.Log(collision.collider.tag);
    }
}
