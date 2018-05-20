using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumablesScript : MonoBehaviour {
    public int coinValue = 0;
    public int bombValue = 0;
    public int keyValue = 0;
    public int hearts = 0;
    //something something bateries
    //something something cards/runes/pills

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
        }

    }

}
