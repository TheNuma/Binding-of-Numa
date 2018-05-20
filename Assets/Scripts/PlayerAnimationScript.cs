using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    Animator animator;
    bool walking;
    bool crying;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        walking = false;
        crying = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            walking = true;
        }
        else
        {
            walking = false;
        }


        //Walking Animation
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetTrigger("OnUp");
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetTrigger("OnRight");
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetTrigger("OnDown");
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetTrigger("OnLeft");
        }

        if (walking == false)
        {
            animator.SetBool("Walking", false);
        }
        if (walking == true)
        {
            animator.SetBool("Walking", true);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            crying = true;
        }
        else
        {
            crying = false;
        }
        //Shooting Animation
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            crying = true;
        }
        else
        {
            crying = false;
        }
        //Shooting Animation
        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetTrigger("OnUpShoot");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetTrigger("OnDownShoot");
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetTrigger("OnLeftShoot");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetTrigger("OnRightShoot");
        }


        if (crying == true)
        {
            animator.SetBool("Crying", true);
        }
        if (crying == false)
        {
            animator.SetBool("Crying", false);
        }
    }



}