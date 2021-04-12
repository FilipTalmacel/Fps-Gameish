using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrowCollision : MonoBehaviour
{
    Rigidbody arrowRb;
    Quaternion lastRotation;
    Transform enemyTransform;

    public float maxArrowTime = 20f;
    void Start()
    {
        arrowRb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        bool kinematicArrow = arrowRb.isKinematic;
        enemyTransform = GetComponentInParent<Transform>();
        if (!kinematicArrow) transform.rotation = Quaternion.LookRotation(enemyTransform.forward, Vector3.up);

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "EnemyArrow" && collision.collider.tag != "Weapon" && collision.collider.tag != "Enemy")
        {
            //Debug.Log(collision.collider.tag);
            //Debug.Log(collision.collider.name);
            Stick();
            Destroy(gameObject, maxArrowTime);
            transform.parent = collision.collider.GetComponent<Transform>();

        }

    }

    void Stick()
    {
        arrowRb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        arrowRb.isKinematic = true;
    }
}
