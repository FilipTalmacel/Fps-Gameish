using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public bool dead;

    public ParticleSystem deathBloodSplatter;

    public EnemyShooting enemyShooting;
    public HealthBar healthBar;
    public EnemyMovement enemyMovement;

    NavMeshAgent enemyAgent;
    Rigidbody enemyRb;

    public GameObject deadEnemyText;
    public GameObject healthBarUI;

    void Start()
    {
        enemyAgent = GameObject.Find("Enemy").GetComponent<NavMeshAgent>();
        enemyRb = GameObject.Find("Enemy").GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Dead()
    {
        dead = true;
        deathBloodSplatter.Play();
        enemyShooting.enabled = false;
        enemyMovement.enabled = false;
        deadEnemyText.SetActive(true);
        healthBarUI.SetActive(false);
        enemyRb.isKinematic = false;
        enemyAgent.enabled = false;
        
    }
}
