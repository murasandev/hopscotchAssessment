using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float speed;
    private int jumpCounter = 1;
    public float jumpForce = 10.0f;

    private Rigidbody rb;
    private Animator anim;

    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
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
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter > 0)
        {
            jumpCounter--;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
