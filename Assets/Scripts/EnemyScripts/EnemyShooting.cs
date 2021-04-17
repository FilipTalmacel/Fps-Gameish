using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public float reloadTime = 3f;
    float timePastReload;
    public float arrowPower = 10f;

    public float arrowsShot;
    public float maxArrows;
    public float currentArrows;

    Transform target;
    public GameObject arrow;
    GameObject enemyArrow;

    public EnemyShooting enemyShooting;


    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.playerInstance.body.transform;

        maxArrows = Random.Range(5, 25);
        //maxArrows = 0;
        currentArrows = maxArrows;
    }

    // Update is called once per frame
    void Update()
    {   
        timePastReload += Time.deltaTime;
        
        if (timePastReload > reloadTime && GameObject.Find("Enemy").GetComponent<EnemyMovement>().detected)
        {
            enemyArrow = Instantiate(arrow, transform) as GameObject;
            enemyArrow.transform.LookAt(target);
            Rigidbody enemyArrowRb = enemyArrow.GetComponent<Rigidbody>();
            enemyArrowRb.isKinematic = false;
            enemyArrowRb.AddForce(enemyArrow.transform.forward * arrowPower, ForceMode.Impulse);
            enemyArrowRb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            enemyArrow.transform.parent = null;
            timePastReload = 0f;
            arrowsShot++;
        }


        currentArrows = maxArrows - arrowsShot;
        if (currentArrows <= 0) enemyShooting.enabled = false;
        else enemyShooting.enabled = true;
    }
}
