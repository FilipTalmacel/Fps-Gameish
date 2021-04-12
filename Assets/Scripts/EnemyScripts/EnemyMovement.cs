using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float enemyDetectionRadius = 30f;
    public float enemyShootingRadius = 20f;
    public float enemyFleeRadius = 10f;
    public float enemyMeleeEngage = 5f;

    public float movementModifier = 5f;

    public bool detected;
    bool dead;

    Transform target;
    NavMeshAgent enemyAgent;
    Rigidbody enemyRb;
    public ParticleSystem deathBloodSplatter;     
    
    public EnemyShooting enemyShooting;
    public HealthBar healthBar;
    public EnemyMovement enemyMovement;
    
    public GameObject deadEnemyText;
    public GameObject healthBarUI;
    
    

    void Start()
    {
        target = PlayerManager.playerInstance.player.transform;
        enemyAgent = GetComponent<NavMeshAgent>();
        dead = false;

        
    }


    void Update()
    {

        enemyRb = GetComponent<Rigidbody>();
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= enemyDetectionRadius)
        {
            enemyAgent.SetDestination(target.position);
            enemyAgent.stoppingDistance = enemyShootingRadius;
            FaceTarget();
            detected = true;
        }
        else detected = false;
        
        if (distance <= enemyShootingRadius + 1 && detected)
        {
            enemyShooting.enabled = true;
        }
        else enemyShooting.enabled = false;

        if (distance < enemyFleeRadius && detected)
        {
            enemyAgent.Move(-transform.forward * Time.deltaTime * movementModifier);
        }

        if((distance < enemyMeleeEngage || enemyShooting.currentArrows == 0) && detected)
        {
            //Change to melee
            enemyAgent.stoppingDistance = 2f;
        }

        if (healthBar.healthSlider.value <= 0 && !dead)
        {
            Dead();
        }
        //deathBloodSplatter.transform.rotation = Quaternion.Euler(90f, 0f , 90f);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0 , direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f) ;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, enemyDetectionRadius);
        Gizmos.DrawWireSphere(transform.position, enemyFleeRadius);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (dead && collision.collider.tag == "Arrow") enemyRb.AddForce(-transform.forward * 2f, ForceMode.Impulse);
    }

    void Dead()
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
