using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollision : MonoBehaviour
{

    Rigidbody arrowRb;
    Quaternion lastRotation;
    
    public bool hasHitSomething;

    public ParticleSystem bloodSplatter;

    public float maxArrowTime = 20f;


    // Start is called before the first frame update
    void Start()
    {
        arrowRb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bool kinematicArrow = arrowRb.isKinematic;
        if (!kinematicArrow)
        {
            lastRotation = Quaternion.LookRotation(arrowRb.velocity.normalized, Vector3.up);
            transform.rotation = lastRotation;
        }

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "Arrow" && collision.collider.tag != "Weapon" && collision.collider.tag != "Player")
        {
            hasHitSomething = true;
            arrowRb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            arrowRb.isKinematic = true;
            transform.rotation = lastRotation;
            Destroy(gameObject, maxArrowTime);
            transform.SetParent(collision.collider.transform);
        }
        if(collision.collider.tag == "Enemy") bloodSplatter.Play();
    }
}
