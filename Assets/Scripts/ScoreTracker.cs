using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public int Score = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
