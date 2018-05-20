using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupScript : MonoBehaviour {

    bool activeItem;
    bool trinket;
    bool consumable;

    
    

    int coins=1;
    int bombs=0;
    int keys=1;


    public Text countCoins;
    public Text countBombs;
    public Text countKeys;



    void Start () {
        activeItem = false;
        trinket = false;
        consumable = false;

        SetCountTexts();
	}
	
	
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {

            coins += other.gameObject.GetComponent<ConsumablesScript>().coinValue;
            SetCountTexts();
            Debug.Log(coins);
        }
        if (other.gameObject.CompareTag("Bomb"))
        {
            bombs += other.gameObject.GetComponent<ConsumablesScript>().bombValue;
            SetCountTexts();
            Debug.Log(bombs);
        }
        if (other.gameObject.CompareTag("Key"))
        {
            keys += other.gameObject.GetComponent<ConsumablesScript>().keyValue;
            SetCountTexts();
            Debug.Log(keys);
        }

        if (other.gameObject.CompareTag("Passive"))
        {

        }
        if (other.gameObject.CompareTag("Active"))
        {
            if (activeItem == false)
            {
                //pickup
                activeItem = true;
            }
            if (activeItem == true)
            {
                //switch items
            }
        }
        if (other.gameObject.CompareTag("Batery"))
        {

        }
        if (other.gameObject.CompareTag("Consumable"))
        {
            if (consumable == false)
            {
                //pickup
                consumable = true;
            }
            if (consumable == true)
            {
                //switch
            }
        }
        if (other.gameObject.CompareTag("Trinket"))
        {
            if (trinket == false)
            {
                //pickup
                trinket = true;
            }
            if (trinket == true)
            {
                //switch
            }
        }
    }

    void SetCountTexts()
    {
        
            countCoins.text = coins.ToString("00");
            countBombs.text = bombs.ToString("00");
            countKeys.text = keys.ToString("00");
       
    }
}


