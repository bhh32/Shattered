using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackFuel : MonoBehaviour
{
    public delegate void OnFuelPickup(float fuelValue);
    public OnFuelPickup OnFuelUpdate;

    public JetpackController jetpackCont;

    
    
}
