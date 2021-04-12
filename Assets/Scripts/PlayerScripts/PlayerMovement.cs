using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform view;

    public CharacterController player;

    private float horizontalX;
    private float vertical;
    public float speed = 1f;
    public float drag = 1f;
    public float groundDistance = 0.2f;
    public float jumpHeight = 4f;
    public int maxJumps = 2;
    private int jumpCount;

    public Animation animationCrouching;

    private Vector3 acceleration;
    private Vector3 velocity;

    bool isGrounded;
    public bool hasJumped;
    public bool isCrouching;
    public bool isSprinting;

    public LayerMask enviorment;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        // A,D,W,S
        horizontalX = Input.GetAxis ("Horizontal");
        vertical = Input.GetAxis ("Vertical");

        isGrounded = Physics.CheckSphere(transform.position, groundDistance, enviorment);

        isCrouching = Input.GetKey(KeyCode.LeftControl) && isGrounded && !hasJumped;
        animationCrouching.Play(isCrouching ? "Crouch" : "Standing");

        hasJumped = (isGrounded || jumpCount < maxJumps) && Input.GetKeyDown(KeyCode.Space);
        jumpCount = hasJumped ? jumpCount + 1 : isGrounded ? 0 : Mathf.Max(jumpCount, 1);
        // if we jump [+1] if we are grounded [0] if both false [1]

        isSprinting = Input.GetKey(KeyCode.LeftShift) && isGrounded && !isCrouching ;

        float currentSpeed = isSprinting ? speed * 2: isCrouching ? speed / 2 : speed ;
        //View
        acceleration = new Vector3();
        acceleration += view.forward * vertical * currentSpeed;
        acceleration += view.right * horizontalX * currentSpeed;
        acceleration.y = Physics.gravity.y;

        velocity += acceleration * Time.deltaTime;

        //Jumping
        if (hasJumped) velocity.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
        else if (isGrounded)velocity.y = 0;

        //Moving
        player.Move(velocity * Time.deltaTime);
        velocity.z *= drag;
        velocity.x *= drag;

        

    }   
}
