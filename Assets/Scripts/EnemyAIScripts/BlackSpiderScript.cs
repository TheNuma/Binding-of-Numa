using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSpiderScript : MonoBehaviour {

    //Damage Stuff
    public float HP = 3.5f;
    bool isDead;
    Animator animator;
    public AnimationClip death;

    //Movement Stuff
    public float maxSpeed = 2f;
    public float dirChangeTime = 2f;
    private Vector2 movement;
    private float timeLeft;
    Transform player;
    private float jumpTime;

    bool moving;

    void Start () {
        
        animator = GetComponent<Animator>();
        isDead = false;
        moving = false;
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

        timeLeft -= Time.deltaTime;
        //jump towards player
        if (Vector2.Distance(player.transform.position, transform.position) <= 3&& timeLeft<=0)
        {
            jumpTime = 1f;
            maxSpeed = 4f;
            movement = player.position - transform.position;
            movement.Normalize();
            timeLeft = Random.Range(1, dirChangeTime);
            moving = true;
        }
        else
        {
            //random movement
            
            if (timeLeft <= 0)
            {
                jumpTime = 1f;
                maxSpeed = 2f;
                movement = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
                timeLeft = Random.Range(1, dirChangeTime);
                moving = true;
            }
        }
        jumpTime -= Time.deltaTime;
        if (jumpTime <= 0)
        {
            maxSpeed = 0;
            jumpTime = 1;
            moving = false;
        }

        if (moving == false)
        {
            animator.SetBool("IsMoving", false);
        }
        if (moving == true)
        {
            animator.SetBool("IsMoving", true);
        }

        Vector2 pos = transform.position;
        pos += (movement * maxSpeed * Time.deltaTime);
        transform.position = pos;
    }

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
