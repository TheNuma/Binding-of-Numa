using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeScript : MonoBehaviour {

    //Chargescript stuff
    public int charge;
    private int maxCharge;
    private int noCharge = 0;
    private int highestCharge=6;
    public int chargeValue = 5;

    public bool isActiveItem=true;


    public Sprite[] chargeSprites;
    Image image;
    private int imageIndex;

    void Start()
    { 
        maxCharge = chargeValue + 1;
        charge = maxCharge;
        image = GetComponent<Image>();
        

        checkChargeAmount();
    }

    void checkChargeAmount()
    {
        if (isActiveItem == true)
        {
            image.enabled = true;
            if (charge == highestCharge)
            {
                imageIndex = 21 + chargeValue;
            }
            else if (charge == highestCharge - 1)
            {
                imageIndex = 20 + chargeValue;
            }
            else if (charge == highestCharge - 2)
            {
                imageIndex = 18 + chargeValue;
            }
            else if (charge == highestCharge - 3)
            {
                imageIndex = 15 + chargeValue;
            }
            else if (charge == highestCharge - 4)
            {
                imageIndex = 11 + chargeValue;
            }
            else if (charge == highestCharge - 5)
            {
                imageIndex = 6 + chargeValue;
            }
            else if (charge == highestCharge - 6)
            {
                imageIndex = 0 + chargeValue;
            }
            image.sprite = chargeSprites[imageIndex];
        }
        if (isActiveItem == false)
        {
            image.enabled = false;
        }
    }


    void Update()
    {
        checkChargeAmount();
    }
}
