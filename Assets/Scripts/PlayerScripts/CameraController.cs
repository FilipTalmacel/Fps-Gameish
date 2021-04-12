using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float sensibility = 1f;

    public float yRotation = 0f;
    public float xRotation = 0f;
    Vector3 euler;


  // Start is called before the first frame update
  void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        euler.x -= mouseY * sensibility * Time.deltaTime;
        euler.y += mouseX * sensibility * Time.deltaTime;

        euler.x = Mathf.Clamp(euler.x, -90f, 90f);

        transform.localEulerAngles = euler;



    }
}
