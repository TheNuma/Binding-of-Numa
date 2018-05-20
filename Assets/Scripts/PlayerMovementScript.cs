using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementScript : MonoBehaviour {

    public float maxSpeed = 5f;


    void Update()
    {
        //move character
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime, Input.GetAxis("Vertical") * maxSpeed*Time.deltaTime, 0);
         pos += velocity;
        
        

        //draw movement
        transform.position = pos;
      
    }
   
}
