using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageScript : MonoBehaviour {

    public int HP = 1;
    bool isDead;
    Animator animator;
    public AnimationClip death;
    public EnemyMovementScript scriptEnemyMovementScript;


    void Start()
    {
        animator = GetComponent<Animator>();
        isDead = false;
        scriptEnemyMovementScript = GetComponent<EnemyMovementScript>();
           
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "PlayerTear")
        {
            HP--;
        }


    }


    void Update()
    {
        if (HP <= 0)
        {


            Die();
        }

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

        scriptEnemyMovementScript.enabled = false;
    }
}

