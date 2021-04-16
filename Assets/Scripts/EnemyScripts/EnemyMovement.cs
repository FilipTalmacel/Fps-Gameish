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

    public float movementModifier = 100f;

    public bool detected;
    bool meleeRange;

    public GameObject bow;
    public GameObject boxerGloves;


    Transform target;
    NavMeshAgent enemyAgent;
    
    public EnemyShooting enemyShooting;
    public EnemyManager enemyManager;
    

    void Start()
    {
        target = PlayerManager.playerInstance.player.transform;
        enemyAgent = GetComponent<NavMeshAgent>();
        meleeRange = false;
    }


    void Update()
    {
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

        if (distance < enemyFleeRadius && detected && !meleeRange)
        {
            enemyAgent.Move(-transform.forward * Time.deltaTime * movementModifier);
        }

        if((distance < enemyMeleeEngage || enemyShooting.currentArrows == 0) && detected)
        {
            meleeRange = true;
            bow.SetActive(false);
            boxerGloves.SetActive(true);
            enemyAgent.stoppingDistance = 2f;
            enemyAgent.SetDestination(target.position);
        }
        else
        {
            meleeRange = false;
            bow.SetActive(true);
            boxerGloves.SetActive(false);
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
        //if (enemyManager.dead && collision.collider.tag == "Arrow") enemyRb.AddForce(-transform.forward * 2f, ForceMode.Impulse);
    }
}
