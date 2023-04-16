using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speed = 10.0f;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }
}
