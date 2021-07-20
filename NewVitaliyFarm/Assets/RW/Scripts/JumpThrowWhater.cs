using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpThrowWhater : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        SheepMove sheep = other.gameObject.GetComponent<SheepMove>();

        if (sheep != null)
        {

            sheep.JumpThrowWater(); 

        }

    }

}
