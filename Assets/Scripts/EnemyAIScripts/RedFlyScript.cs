using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFlyScript : MonoBehaviour {
    //Damage Stuff
    public float HP = 1;
    bool isDead;
    Animator animator;
    public AnimationClip death;
    

    //Movement Stuff
    public float maxSpeed = 2f;
    public float rotSpeed = 90f;
    Transform player;

    void Start()
    {
        //Damage Stuff
        animator = GetComponent<Animator>();
        isDead = false;

    }
    //Damage Stuff
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "PlayerTear")
        {
            HP--;
        }


    }


    void Update()
    {
        //damage stuff
        if (HP <= 0)
        {
            Die();
        }
        //Movement Stuff
        //find player
        if (player == null)
        {
            GameObject go = GameObject.Find("Player");
            if (go != null)
            {
                player = go.transform;
            }
        }
        if (player == null)
        {
            return;
        }




        //point at player

        if (isDead == true)
        {
            maxSpeed = 0;
        }
        Vector3 dir = player.position - transform.position;
        dir.Normalize();

        //float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        //Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);



        Vector3 pos = transform.position;
        pos += (dir * maxSpeed * Time.deltaTime);
        transform.position = pos;

        

    }
    //Damage Stuff
    void Die()
    {
        isDead = true;
        if (isDead == true)
        {
            animator.SetBool("IsDead", true);
        }
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        Destroy(this.gameObject, death.length);     
    }
}
