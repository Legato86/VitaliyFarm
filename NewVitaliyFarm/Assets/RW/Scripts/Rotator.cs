using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Vector3 rotateAxis;
    private Transform wheelTrans;
    

    void Start()
    {
        wheelTrans = transform.GetChild(0).GetChild(0);

    }

    // Update is called once per frame
    void Update()
    {
        
        wheelTrans.transform.Rotate(rotateAxis * rotateSpeed * Time.deltaTime); 
    }
}
