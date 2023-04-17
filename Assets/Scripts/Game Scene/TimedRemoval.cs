using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedRemoval : MonoBehaviour
{
    public float TimeToRemoval;

    private void Awake()
    {
        Invoke(nameof(Remove), TimeToRemoval);
    }

    private void Remove()
    {
        Destroy(this.gameObject);
    }
}
