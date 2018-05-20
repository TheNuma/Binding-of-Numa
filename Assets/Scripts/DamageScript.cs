using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScript : MonoBehaviour {


    private int maxHearts = 12;
    public int startHearts = 2;
    public int HP;
    public int maxHP;
    private int healthPerHeart=2;
    private int maxHPavailable;

    public Image[] healthImages;
    public Sprite[] healthSprites;

    bool isDead;
    Animator animator;
    public AnimationClip death;
    public PlayerMovementScript scriptPlayerMovementScript;
    


    

    void Start ()
    {
        animator = GetComponent<Animator>();
        isDead = false;
        scriptPlayerMovementScript = GetComponent<PlayerMovementScript>();

        HP=startHearts*healthPerHeart;
        maxHP =HP;
        maxHPavailable = maxHearts * healthPerHeart;

        checkHealthAmount();
        
    }

    void checkHealthAmount()
    {
        for(int i = 0; i < maxHearts; i++)
        {
            if (startHearts <= i)
            {
                healthImages[i].enabled = false;
            }
            else
            {
                healthImages[i].enabled = true;
            }
        }
        UpdateHearts();
    }

    void UpdateHearts()
    {
        bool empty = false;
        int i = 0;

        foreach(Image image in healthImages)
        {
            if (empty)
            {
                image.sprite = healthSprites[0];
            }
            else
            {
                i++;
                if (HP >= i * healthPerHeart)
                {
                    image.sprite = healthSprites[2];
                }
                else
                {
                    int currentHP = (int)(healthPerHeart - (healthPerHeart * i - HP));
                    int healthPerImage = 1;
                    int imageIndex = currentHP / healthPerImage;
                    image.sprite = healthSprites[imageIndex];
                    empty = true;
                }
            }
        }

        
    }

    public void AddHeartContainer()
    {
        startHearts++;
        startHearts = Mathf.Clamp(startHearts, 0, maxHearts);
        checkHealthAmount();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        HP = Mathf.Clamp(HP, 0, startHearts * healthPerHeart);
        if (other.gameObject.tag=="Enemy")
        {
            HP--;
            UpdateHearts();
            Debug.Log("Ouch!");
        }

        if (other.gameObject.CompareTag("Heart"))
        {
            
            if (HP == maxHP|| HP > maxHP)
            {
                //dont pickup
            }
            if (HP < maxHP && HP > 0)
            {
                HP += other.gameObject.GetComponent<ConsumablesScript>().hearts;
                
                if (HP > maxHP)
                {
                   HP = maxHP;
                }
                UpdateHearts();
            }
            
        }

    }


    void Update ()
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
        Destroy(gameObject.GetComponent<PolygonCollider2D>());
        Destroy(this.gameObject, death.length);
        //makestop moving
        scriptPlayerMovementScript.enabled = false;

        
    }
}
