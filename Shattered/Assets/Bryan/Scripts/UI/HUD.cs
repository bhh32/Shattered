using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public delegate void OnHudUpdate(float value);
    public OnHudUpdate UpdateHud;

    [SerializeField] Slider jetpackFuelSlider;

    private void Start()
    {
        UpdateHud += OnFuelUpdate;
    }

    void OnFuelUpdate(float value)
    {
        jetpackFuelSlider.value = value;
    }


}
