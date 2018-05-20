using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingScript : MonoBehaviour {

    

    public float fireDelay = 0.35f;
    public float cooldownTimer = 0;

    public GameObject tears;
    bool leftEye;

    void Start()
    {
        leftEye = true;
    }



    void Update ()
    {

        cooldownTimer -= Time.deltaTime;

        Vector3 offsetDown =  new Vector3(0, -0.45f, 0);
        Vector3 offsetUp = new Vector3(0, 0.25f, 0);
        Vector3 left = new Vector3(0.2f, 0, 0);
        Vector3 right =  new Vector3(-0.2f, 0, 0);
        Vector3 up = new Vector3(0, 0.0f, 0);
        Vector3 down= new Vector3(0, -0.4f, 0);
        Vector3 offsetRight = new Vector3(0.40f, 0, 0);
        Vector3 offsetLeft= new Vector3(-0.40f, 0, 0);

        Quaternion tearAngle = transform.rotation;

        if (Input.GetKey(KeyCode.DownArrow) && cooldownTimer <= 0)
        {
            if (leftEye == true)
            {

                Instantiate(tears, transform.position + offsetDown + left, transform.rotation);
                leftEye = false;
                cooldownTimer = fireDelay;


            }
            else
            {

                Instantiate(tears, transform.position + offsetDown + right, transform.rotation);

                leftEye = true;
                cooldownTimer = fireDelay;
            }

        }
        if (Input.GetKey(KeyCode.UpArrow) && cooldownTimer <= 0)
        {
            tearAngle = Quaternion.Euler(0, 0, 180f);
            if (leftEye == true)
            {
                Instantiate(tears, transform.position + offsetUp + right, tearAngle);
                leftEye = false;
                cooldownTimer = fireDelay;


            }
            else
            {

                Instantiate(tears, transform.position + offsetUp + left, tearAngle);

                leftEye = true;
                cooldownTimer = fireDelay;
            }

        }

        if (Input.GetKey(KeyCode.RightArrow) && cooldownTimer <= 0)
        {
            tearAngle = Quaternion.Euler(0, 0, 90f);
            if (leftEye == true)
            {

                Instantiate(tears, transform.position + offsetRight + up, tearAngle);
                leftEye = false;
                cooldownTimer = fireDelay;


            }
            else
            {

                Instantiate(tears, transform.position + offsetRight + down, tearAngle);

                leftEye = true;
                cooldownTimer = fireDelay;
            }

        }
        if (Input.GetKey(KeyCode.LeftArrow) && cooldownTimer <= 0)
        {
            tearAngle = Quaternion.Euler(0, 0, 270f);
            if (leftEye == true)
            {

                Instantiate(tears, transform.position + offsetLeft + down, tearAngle);
                leftEye = false;
                cooldownTimer = fireDelay;


            }
            else
            {

                Instantiate(tears, transform.position + offsetLeft + up, tearAngle);

                leftEye = true;
                cooldownTimer = fireDelay;
            }

        }


    }
}
