using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHungerBar : MonoBehaviour
{
    private Slider slider;
    private Animal animal;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        animal = GetComponentInParent<Animal>();
    }

    private void Update()
    {
        slider.value = (float)animal.Satiation / (float)animal.Hunger;
    }
}
