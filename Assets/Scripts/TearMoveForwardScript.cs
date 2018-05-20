using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearMoveForwardScript : MonoBehaviour {
    public float maxSpeed = 5f;
    public float tearRange = 1f;
    public float HP = 1f;
    public GameObject tearDeath;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            HP--;
           
        }


    }


    void Update ()
    {
        if (HP <= 0)
        {
            Die();
        }
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, -maxSpeed * Time.deltaTime, 0);
      
        pos += transform.rotation*velocity;
        transform.position = pos;

        tearRange -= Time.deltaTime;
        if (tearRange <= 0)
        {
            Die();
        }

	}
    void Die()
    {
        Destroy(gameObject);
        Instantiate(tearDeath, transform.position, transform.rotation);
    }
   

}
