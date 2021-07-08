using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SheepMove sheep = other.gameObject.GetComponent<SheepMove>();

        if(sheep != null)
        {
            Destroy(other.gameObject); 

        }




    }
}
