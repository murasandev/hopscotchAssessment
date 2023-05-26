using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RunForward()
    {
        anim.SetBool("Run", true);
        anim.SetBool("Run L", false);
        anim.SetBool("Run R", false);
    }

    public void RunLeft()
    {
        anim.SetBool("Run L", true);
    }

    public void RunRight()
    {
        anim.SetBool("Run R", true);
    }

    public void Jump()
    {
        anim.SetBool("Jump", true);
    }

    public void JumpEnd()
    {
        anim.SetBool("Jump", false);
    }
}
