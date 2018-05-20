using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackFlyScript : MonoBehaviour {

    //Damage Stuff
    public float HP = 1;
    bool isDead;
    Animator animator;
    public AnimationClip death;


    //Movement Stuff
    public float maxSpeed = 0.5f;
    public float dirChangeTime = 2f;
    private Vector2 movement;
    private float timeLeft;
    

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
        //point at player

        if (isDead == true)
        {
            maxSpeed = 0;
        }

        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft = Random.Range(0,dirChangeTime);
        }
    }

    void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos += (movement * maxSpeed*Time.deltaTime);
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
