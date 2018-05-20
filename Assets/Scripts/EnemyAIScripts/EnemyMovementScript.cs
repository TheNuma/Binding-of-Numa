using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour {

    public float maxSpeed = 2f;
    public float rotSpeed = 90f;
    Transform player;


    void Start () {
		
	}
	
	
	void Update ()
    {
        //find player
        if (player == null)
        {
            GameObject go = GameObject.Find("Player");
            if (go != null)
            {
                player = go.transform;
            }
        }
        if (player==null)
        {
            return;
        }

        

       
        //point at player
        Vector3 dir = player.position - transform.position;
        dir.Normalize();

        //float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        //Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);



        Vector3 pos = transform.position;
        pos += (dir * maxSpeed * Time.deltaTime);
        transform.position = pos;
    }
}
