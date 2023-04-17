using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;

public class UIFed : MonoBehaviour
{
    public int Points;

    private TMP_Text textObj;

    private void Awake()
    {
        textObj = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        textObj.text = "Thanks\n+" + Points;
    }
}
