using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var animal = other.gameObject.GetComponent<Animal>();
        if (animal)
        {
            animal.Feed();
        }
    }

    public void Eat()
    {
        Destroy(this.gameObject);
    }
}
