using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 moveDirection;

    [SerializeField] private float force;
    private Rigidbody rb;
    [SerializeField] private GameObject HeartParticlePrefab;

    private void Awake()  // private - скрывает компонент 
    {

        rb = GetComponent<Rigidbody>();

    }


    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime); 
    }

    public void SaveSheep()
    {
        rb.isKinematic = false;
        rb.AddForce(Vector3.up * force);
        ///////////////////////// тут делать
        //1. Отключить скорость овце на 0 или как в тракторе 
        //2. отключить бокс коллайдер овце 
        //3. отключить гравитацию
        //4. Спаунить патикл со здвигом над овцой или за овцой

        GameObject particle = Instantiate(HeartParticlePrefab, transform.position, HeartParticlePrefab.transform.rotation);  // спауним патикл в позиции овци 
        Destroy(particle, 2f);
        Destroy(gameObject, 0.9f);
    }
    public void SheepJump() 
    {
        rb.isKinematic = false;
        moveSpeed = 0;
        rb.AddForce(Vector3.up * force);
        rb.isKinematic =  true;
        moveSpeed = 1; 

    }
}

