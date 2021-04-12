using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBilboard : MonoBehaviour
{
    public Transform playerCamera;



    // Update is called once per frame
    public void Update()
    {
        
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + playerCamera.forward);
    }
}
