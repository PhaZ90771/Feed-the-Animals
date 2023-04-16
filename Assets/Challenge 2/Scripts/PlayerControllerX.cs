using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float cooldown = 1.0f;
    private float nextDogSpawn = 0f;

    private void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && nextDogSpawn <= Time.time)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            nextDogSpawn = Time.time + cooldown;
        }
    }
}
