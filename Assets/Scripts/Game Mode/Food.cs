using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var animal = other.gameObject.GetComponent<Animal>();
        if (animal)
        {
            animal.Feed();
        }
    }

    public void Eat()
    {
        Destroy(this.gameObject);
    }
}
