using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{

    public LayerMask itemsMask;

    public ReloadShooting reloadShooting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] nearbyItems = Physics.OverlapSphere(transform.position, 3f, itemsMask);
            if(nearbyItems.Length > 0)
            {
                float closestDistance = float.MaxValue;
                Collider closestCollider = null;
                foreach(Collider collider in nearbyItems)
                {
                    float currentDistance = Vector3.Distance(collider.transform.position, transform.position) ;
                    if(currentDistance < closestDistance && collider.GetComponentInParent<ArrowCollision>().hasHitSomething)
                    {
                        closestDistance = currentDistance;
                        closestCollider = collider;
                    }
                }
                if(closestCollider != null)
                {
                    Destroy(closestCollider.gameObject);
                    reloadShooting.arrowsShot--;
                }
            }
        }
    }
}
