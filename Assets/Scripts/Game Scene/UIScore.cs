using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    private PlayerController player;
    private TMP_Text textObj;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        textObj = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        textObj.text = "Score: " + player.Score.ToString();
    }
}
