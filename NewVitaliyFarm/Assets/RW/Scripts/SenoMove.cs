using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenoMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Vector3 rotateDirection;

    private Transform senoMode1;
    void Start()
    {
        senoMode1 = transform.GetChild(0);
    }   

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        senoMode1.transform.Rotate(rotateDirection * rotateSpeed * Time.deltaTime);
    }
}
