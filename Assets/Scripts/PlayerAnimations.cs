using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator anim;


    void Awake()
    {
        anim = GetComponent<Animator>();
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

    public void JumpStart()
    {
        anim.SetBool("Jump", true);
    }

    public void JumpEnd()
    {
        anim.SetBool("Jump", false);
    }

    public void Slide()
    {
        anim.SetTrigger("Slide");
    }

    public void Win()
    {
        anim.SetTrigger("Win");
    }
}
