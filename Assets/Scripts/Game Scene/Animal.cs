using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public float Hunger = 1f;
    public float Satiation = 0f;

    private void OnTriggerEnter(Collider other)
    {
        var food = other.gameObject.GetComponent<Food>();
        var player = other.gameObject.GetComponent<PlayerController>();
        if (food)
        {
            food.Eat();
        }
        else if (player)
        {
            player.Kill();
        }
    }

    public void Feed()
    {
        Satiation++;
        if (Satiation >= Hunger)
        {
            Destroy(this.gameObject);
        }
    }
}
