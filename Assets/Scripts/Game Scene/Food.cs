using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private ScoreTracker scoreTracker;

    private void Awake()
    {
        scoreTracker = FindObjectOfType<ScoreTracker>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var animal = other.gameObject.GetComponent<Animal>();
        if (animal)
        {
            animal.Feed();
            scoreTracker.Score++;
        }
    }

    public void Eat()
    {
        Destroy(this.gameObject);
    }
}
