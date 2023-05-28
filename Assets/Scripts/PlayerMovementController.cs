using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerAnimations anim;

    public float speed;
    private float slideCD = 1.25f;
    private bool canSlideBool = true;
    private bool isSliding;

    #region Jump Variables
    public int jumpCounter = 1;
    public float jumpForce = 10.0f;
    bool jumpKeyPressed;
    #endregion

    private float xConstraint = 3.5f;
    private float zTopConstraint = -5f;
    private float zBotConstraint = 1f;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<PlayerAnimations>();

        if (anim != null)
        {
            anim.RunForward();
        }
    }
    private void LateUpdate()
    {
        PositionConstraint();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Movement();
            Slide();
            JumpInput();  
        }
    }

    private void FixedUpdate()
    {
        if (jumpKeyPressed)
        {
            Jump(); 
        }
    }

    void Movement()
    {
        //move forward
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward *Time.deltaTime * speed);
        }
        //move backward
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        //move Left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            anim.RunLeft();
        }
        //move Right
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            anim.RunRight();
        }
        else
        {
            anim.RunForward();
        }
    }
    
    void PositionConstraint()
    {
        //x constraints
        if (transform.position.x >= xConstraint)
        {
            transform.position = new Vector3(xConstraint, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -xConstraint)
        {
            transform.position = new Vector3(-xConstraint, transform.position.y, transform.position.z);
        }

        //z constraints
        if (transform.position.z <= zTopConstraint)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zTopConstraint);
        }
        if (transform.position.z >= zBotConstraint)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBotConstraint);
        }
    }

    #region Jump Mechanics
    void JumpInput()
    {   
        //Get Jump Input in Update
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter > 0 && !isSliding)
        {
            jumpKeyPressed = true;
        }
    }
    void Jump()
    {
        //Do Jump in Fixed Update
        jumpCounter--;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        anim.JumpStart();
        jumpKeyPressed = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //When Grounded reset jump counter
            jumpCounter = 1;
            anim.JumpEnd();
        }
    }
    #endregion

    void Slide()
    {
        if (Input.GetKeyDown(KeyCode.C) && canSlideBool)
        {
            isSliding = true;
            anim.Slide();
            Invoke("canSlide", slideCD);
            canSlideBool = false;
        }
    }

    void canSlide()
    {
        canSlideBool = true;
        isSliding = false;
    }
}
