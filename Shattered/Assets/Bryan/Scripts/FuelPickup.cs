using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPickup : MonoBehaviour
{
    [SerializeField] JetpackFuel jetpackFuel;
    [SerializeField] float fuelValue;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            jetpackFuel.OnFuelUpdate += PickupFuel;
            jetpackFuel.OnFuelUpdate(fuelValue);
            jetpackFuel.OnFuelUpdate -= PickupFuel;
            Destroy(this.gameObject);
        }
    }

    void PickupFuel(float fuelValue)
    {
        if (jetpackFuel.jetpackCont.jetpackFuel < 100f)
        {
            jetpackFuel.jetpackCont.jetpackFuel += fuelValue;

            if (jetpackFuel.jetpackCont.jetpackFuel > 100f)
                jetpackFuel.jetpackCont.jetpackFuel = 100f;
        }
    }
}
