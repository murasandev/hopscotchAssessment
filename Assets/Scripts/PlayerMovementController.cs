using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float speed;
    public int jumpCounter = 1;
    public float jumpForce = 10.0f;

    private Rigidbody rb;
 
    private PlayerAnimations anim;

    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<PlayerAnimations>();

        anim.RunForward();
    }
    private void LateUpdate()
    {
        LateralConstraint();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            LateralMovement();
            Jump();
        }
    }
    
    void LateralMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            anim.RunLeft();
        }
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
    
    void LateralConstraint()
    {
        if (transform.position.x >= 3.0f)
        {
            transform.position = new Vector3(3.0f, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -3.0f)
        {
            transform.position = new Vector3(-3.0f, transform.position.y, transform.position.z);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter > 0)
        {
            jumpCounter--;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            anim.Jump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCounter = 1;
            anim.JumpEnd();
        }
    }
}
