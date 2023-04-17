using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public int Hunger = 1;
    public int Satiation = 0;
    public GameObject satiationEffectPrefab;

    private ScoreTracker scoreTracker;

    private void Awake()
    {
        scoreTracker = FindObjectOfType<ScoreTracker>();
    }

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
            scoreTracker.Score += Hunger;

            var effectPos = transform.position + satiationEffectPrefab.transform.position;
            var effectRot = satiationEffectPrefab.transform.rotation;
            Instantiate(satiationEffectPrefab, effectPos, effectRot, null);
            Destroy(this.gameObject);
        }
    }
}
