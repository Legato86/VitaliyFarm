using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWorkTime : MonoBehaviour
{
    //If the Aim button is pressed, a senoPrefab
    //will be Instantiated every 0.5 seconds.

    public GameObject senoPrefab;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButton("Aim") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(senoPrefab, transform.position, transform.rotation);
        }

    }
    public void PressAim() 
    {

    }
}   








