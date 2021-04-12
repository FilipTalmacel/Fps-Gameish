using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadShooting : MonoBehaviour
{
    public GameObject arrow;
    GameObject newArrow;

    public float arrowPower = 1f;
    public float arrowsShot = 0f;

    public bool isReloaded;

    public LayerMask itemsMask;

    
    void Start()
    {

    }
   
    // Update is called once per frame
    void Update()
    {
        Camera cameraView = GameObject.Find("view").GetComponent<Camera>();
        

        if (Input.GetKeyDown(KeyCode.R) && isReloaded == false)
        {
            newArrow = Instantiate(arrow, transform);
            isReloaded = true;
            arrowsShot++;
        }

        if (Input.GetMouseButtonDown(0) && newArrow != null)
        {
            Rigidbody arrowRb = newArrow.GetComponent<Rigidbody>();
            isReloaded = false;
            arrowRb.velocity = cameraView.transform.forward * arrowPower;
            arrowRb.isKinematic = false;
            arrowRb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            newArrow.transform.parent = null;
            newArrow = null;
        }

    }
}

