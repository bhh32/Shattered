using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPickup : MonoBehaviour
{
    [SerializeField] JetpackFuel jetpackFuel;
    [SerializeField] HUD hud;
    [SerializeField] float fuelValue;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            // add the pickupfuel method to the delegate 
            jetpackFuel.OnFuelUpdate += PickupFuel;
            // call the delegate using the fuel value of this pickup
            jetpackFuel.OnFuelUpdate(fuelValue);            
        }
    }

    void PickupFuel(float fuelValue)
    {
        // If the jetpack fuel is less than 100% run the method
        if (jetpackFuel.jetpackCont.jetpackFuel < 100f)
        {
            jetpackFuel.jetpackCont.jetpackFuel += fuelValue;

            if (jetpackFuel.jetpackCont.jetpackFuel > 100f)
                jetpackFuel.jetpackCont.jetpackFuel = 100f;

            hud.UpdateHud(jetpackFuel.jetpackCont.jetpackFuel);

            jetpackFuel.OnFuelUpdate -= PickupFuel;
            Destroy(gameObject);
        }
    }
}
