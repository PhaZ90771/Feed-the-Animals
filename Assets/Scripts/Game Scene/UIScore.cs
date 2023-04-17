using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    private ScoreTracker scoreTracker;
    private TMP_Text textObj;

    private void Awake()
    {
        scoreTracker = FindObjectOfType<ScoreTracker>();
        textObj = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        textObj.text = "Thanks: " + scoreTracker.Score.ToString();
    }
}
